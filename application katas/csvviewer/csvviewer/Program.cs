using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class MainClass
	{
		public static void Main (string[] args)
		{
			var con = new ConsolePortal ();
			var app = new App (con);

			app.Run (args);
		}
	}


	class App {
		ConsolePortal con;
		CsvCache cache;

		public App(ConsolePortal con) {
			this.con = con;
		}

		public void Run(string[] args) {
			var cli = new CliPortal ();
			var dat = new DateiProvider ();

			var dateiname = cli.Starten (args);
			var csvzeilen = dat.Datei_laden (dateiname);
			this.cache = new CsvCache (csvzeilen);

			var tabellenzeilen = Erste_Seite_aufblättern ();
			con.Tabelle_anzeigen (tabellenzeilen);
		}


		IEnumerable<string> Erste_Seite_aufblättern() {
			var blättern = new Blättern ();
			var csvtab = new csv_tabellierer.CSVTabellierer ();

			var csvseite = blättern.Erste_Seite_ermitteln (this.cache);
			return csvtab.Tabellieren (csvseite.Zeilen);
		}

	}
}
