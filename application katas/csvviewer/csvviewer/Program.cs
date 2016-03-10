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
}
