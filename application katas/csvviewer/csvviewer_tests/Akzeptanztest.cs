using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer_tests
{
	[TestFixture ()]
	public class Akzeptanztest
	{
		[Test ()]
		public void Run ()
		{
			var cli = new MockCliPortal ();
			var con = new MockConsolePortal ();
			var sut = new  csvviewer.App (cli, con);

			sut.Run (new[]{"beispieldaten/zahlen.csv", "3"});
			Assert.That (con.Tabellenzeilen, Is.EqualTo (new[]{
				"Zahlen|",
				"------+",
				"1     |",
				"2     |",
				"3     |"
			}));

			con.Kommando_triggern ('l');
			Assert.That (con.Tabellenzeilen, Is.EqualTo (new[]{
				"Zahlen|",
				"------+",
				"13    |"
			}));

			con.Kommando_triggern ('v');
			Assert.That (con.Tabellenzeilen, Is.EqualTo (new[]{
				"Zahlen|",
				"------+",
				"10    |",
				"11    |",
				"12    |"
			}));

			con.Kommando_triggern ('e');
			con.Kommando_triggern ('n');
			Assert.That (con.Tabellenzeilen, Is.EqualTo (new[]{
				"Zahlen|",
				"------+",
				"4     |",
				"5     |",
				"6     |"
			}));
		}



		class MockCliPortal : csvviewer.ICliPortal {
			#region ICliPortal implementation
			public event Action<string, int> BeiKommandozeilenparameter;
			public void Starten (string[] args)
			{
				BeiKommandozeilenparameter (args [0], int.Parse(args [1]));
			}
			#endregion
		}


		class MockConsolePortal : csvviewer.IConsolePortal {
			public List<string> Tabellenzeilen;


			#region IConsolePortal implementation
			public event Action ErsteSeiteCmd;
			public event Action LetzteSeiteCmd;
			public event Action NächsteSeiteCmd;
			public event Action VorherigeSeiteCmd;

			public void Tabelle_anzeigen (IEnumerable<string> tabellenzeilen)
			{
				this.Tabellenzeilen = new List<string> (tabellenzeilen);
			}

			public void Menü_anzeigen ()
			{
				
			}
			#endregion


			public void Kommando_triggern(char kommandozeichen) {
				switch (kommandozeichen) {
				case 'e':
					ErsteSeiteCmd ();
					break;
				case 'l':
					LetzteSeiteCmd ();
					break;
				case 'n':
					NächsteSeiteCmd ();
					break;
				case 'v':
					VorherigeSeiteCmd ();
					break;
				}
			}
		}
	}
}

