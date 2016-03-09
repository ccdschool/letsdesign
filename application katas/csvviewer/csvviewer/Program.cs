﻿using System;
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

		public App(ConsolePortal con) {
			this.con = con;
		}

		public void Run(string[] args) {
			var cli = new CliPortal ();

			var dateiname = cli.Starten (args);
			var tabellenzeilen = Erste_Seite_aufblättern (dateiname);
			con.Tabelle_anzeigen (tabellenzeilen);
		}


		IEnumerable<string> Erste_Seite_aufblättern(string dateiname) {
			var dat = new DateiProvider ();
			var blättern = new Blättern ();
			var csvtab = new csv_tabellierer.CSVTabellierer ();

			var csvzeilen = dat.Datei_laden (dateiname);
			var csvseite = blättern.Erste_Seite_ermitteln (csvzeilen);
			return csvtab.Tabellieren (csvseite.Zeilen);
		}

	}


	class Blättern {
		const int SEITENLÄNGE = 10;

		public CsvSeite Erste_Seite_ermitteln(IEnumerable<string> csvzeilen) {
			return new CsvSeite{ 
				Überschriftenzeile = csvzeilen.First(),
				Datenzeilen = csvzeilen.Skip(1).Take(SEITENLÄNGE)
			};
		}
	}

}
