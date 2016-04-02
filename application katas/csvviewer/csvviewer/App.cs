using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class App {
		Blättern blättern;
		csv_tabellierer.CSVTabellierer csvtab;
		CliPortal cli;
		ConsolePortal con;
		CsvCache cache;

		public App(CliPortal cli, ConsolePortal con) {
			this.cli = cli;
			this.con = con;

			var dat = new DateiProvider ();
			this.blättern = new Blättern ();
			this.csvtab = new csv_tabellierer.CSVTabellierer ();


			this.cli.BeiDateiname += dateiname => {
				var csvzeilen = dat.Datei_laden (dateiname);
				this.cache = new CsvCache (csvzeilen);

				var tabellenzeilen = Erste_Seite_aufblättern (this.cache);
				con.Öffnen (tabellenzeilen);	
			};

			this.con.ErsteSeiteCmd += () => {
				var tabellenzeilen = Erste_Seite_aufblättern (this.cache);
				con.Tabelle_anzeigen (tabellenzeilen);
			};
			this.con.LetzteSeiteCmd += () =>  {
				var letzteTabellenzeilen = Letzte_Seite_aufblättern (this.cache);
				con.Tabelle_anzeigen (letzteTabellenzeilen);	
			};
		}

		public void Run(string[] args) {
			this.cli.Starten (args);
		}


		IEnumerable<string> Erste_Seite_aufblättern(CsvCache cache) {
			var csvseite = blättern.Erste_Seite_ermitteln (cache);
			return csvtab.Tabellieren (csvseite.Zeilen);
		}

		IEnumerable<string> Letzte_Seite_aufblättern(CsvCache cache) {
			var csvseite = blättern.Letzte_Seite_ermitteln (cache);
			return csvtab.Tabellieren (csvseite.Zeilen);
		}
	}
}
