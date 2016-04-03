using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class App {
		Interaktionen interaktionen;
		CliPortal cli;
		ConsolePortal con;

		public App(CliPortal cli, ConsolePortal con) {
			this.cli = cli;
			this.con = con;
			var dat = new DateiProvider ();

			this.cli.BeiKommandozeilenparameter += (dateiname, seitenlänge) => {
				var csvzeilen = dat.Datei_laden (dateiname);

				var cache = new CsvCache (csvzeilen);
				var blättern = new Blättern(cache, seitenlänge);
				this.interaktionen = new Interaktionen(blättern);
				this.interaktionen.BeiTabelle += con.Tabelle_anzeigen;

				this.interaktionen.Erste_Seite_aufblättern ();
				con.Menü_anzeigen ();	
			};


			this.con.ErsteSeiteCmd += () => this.interaktionen.Erste_Seite_aufblättern();
			this.con.LetzteSeiteCmd += () => this.interaktionen.Letzte_Seite_aufblättern();
			this.con.NächsteSeiteCmd += () => this.interaktionen.Nächste_Seite_aufblättern();
			this.con.VorherigeSeiteCmd += () => this.interaktionen.Vorherige_Seite_aufblättern();
		}

		public void Run(string[] args) {
			this.cli.Starten (args);
		}



		class Interaktionen {
			Blättern blättern;
			csv_tabellierer.CSVTabellierer csvtab;

			public Interaktionen(Blättern blättern) {
				this.blättern = blättern;
				this.csvtab = new csv_tabellierer.CSVTabellierer();
			}


			public void Erste_Seite_aufblättern() {
				var csvseite = this.blättern.Erste_Seite_ermitteln ();
				BeiTabelle (csvtab.Tabellieren (csvseite.Zeilen));
			}

			public void Letzte_Seite_aufblättern() {
				var csvseite = this.blättern.Letzte_Seite_ermitteln ();
				BeiTabelle (csvtab.Tabellieren (csvseite.Zeilen));
			}

			public void Nächste_Seite_aufblättern() {
				var csvseite = this.blättern.Nächste_Seite_ermitteln ();
				BeiTabelle (csvtab.Tabellieren (csvseite.Zeilen));
			}

			public void Vorherige_Seite_aufblättern() {
				var csvseite = this.blättern.Vorherige_Seite_ermitteln ();
				BeiTabelle (csvtab.Tabellieren (csvseite.Zeilen));
			}


			public event Action<IEnumerable<string>> BeiTabelle;
		}
	}
}
