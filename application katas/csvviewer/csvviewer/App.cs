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

		public App(CliPortal cli, ConsolePortal con) {
			this.cli = cli;
			this.con = con;

			var dat = new DateiProvider ();

			this.csvtab = new csv_tabellierer.CSVTabellierer ();


			this.cli.BeiKommandozeilenparameter += (dateiname, seitenlänge) => {
				var csvzeilen = dat.Datei_laden (dateiname);
				var cache = new CsvCache (csvzeilen);
				this.blättern = new Blättern (cache, seitenlänge);

				var tabellenzeilen = Erste_Seite_aufblättern ();
				con.Öffnen (tabellenzeilen);	
			};

			this.con.ErsteSeiteCmd += () => {
				var tabellenzeilen = Erste_Seite_aufblättern ();
				con.Tabelle_anzeigen (tabellenzeilen);
			};
			this.con.LetzteSeiteCmd += () =>  {
				var letzteTabellenzeilen = Letzte_Seite_aufblättern ();
				con.Tabelle_anzeigen (letzteTabellenzeilen);	
			};
			this.con.NächsteSeiteCmd += () => {
				var letzteTabellenzeilen = Nächste_Seite_aufblättern ();
				con.Tabelle_anzeigen (letzteTabellenzeilen);	
			};
			this.con.VorherigeSeiteCmd += () => {
				var letzteTabellenzeilen = Vorherige_Seite_aufblättern ();
				con.Tabelle_anzeigen (letzteTabellenzeilen);	
			};
		}

		public void Run(string[] args) {
			this.cli.Starten (args);
		}


		IEnumerable<string> Erste_Seite_aufblättern() {
			var csvseite = blättern.Erste_Seite_ermitteln ();
			return csvtab.Tabellieren (csvseite.Zeilen);
		}

		IEnumerable<string> Letzte_Seite_aufblättern() {
			var csvseite = blättern.Letzte_Seite_ermitteln ();
			return csvtab.Tabellieren (csvseite.Zeilen);
		}

		IEnumerable<string> Nächste_Seite_aufblättern() {
			var csvseite = blättern.Nächste_Seite_ermitteln ();
			return csvtab.Tabellieren (csvseite.Zeilen);
		}

		IEnumerable<string> Vorherige_Seite_aufblättern() {
			var csvseite = blättern.Vorherige_Seite_ermitteln ();
			return csvtab.Tabellieren (csvseite.Zeilen);
		}
	}
}
