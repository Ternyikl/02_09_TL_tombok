using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_09_TL_tombok
{
	internal class Program
	{
		#region F01 Karneváli tombola
		static string[] TombolaSorsolas(int[] sorjegyek, string[] nyeremenyek )
		{
			string[] nyertesek = new string[5];
			int[] seged = new int[5] {-1, -1, -1, -1, -1 };
			bool szerepel = false;
			Random rnd = new Random();

			for ( int i = 0; i < nyeremenyek.Length; i++)
			{
				int nyertes = -1;
				do
				{
					szerepel = false;
					nyertes = rnd.Next(0, 100);
					for( int j = 0; j < seged.Length; j++)
					{
						if( seged[j] == nyertes )
						{
							szerepel = true;
							break;
						}
					}
				} while (szerepel);
				seged[i] = nyertes;
				nyertesek[i] = $"A(z) {sorjegyek[nyertes]} sorszámú személy nyerte a(z) {nyeremenyek[i]}";
			}
			return nyertesek;
		}
		static void F01() 
		{
			int[] sorjegyek = new int[100];
			string[] nyeremenyek = new string[5];
			for (int i = 0; i < sorjegyek.Length; i++)
			{
				sorjegyek[i] = i + 1;
			}

			nyeremenyek[0] = "Élmény hajózás a hely tavon";
			nyeremenyek[1] = "Vacsora egy hely exkluszív étteremben";
			nyeremenyek[2] = "Egy páros belépő egy luxus szállodába";
			nyeremenyek[3] = "Egy utazási utalvány Spanyolországba";
			nyeremenyek[4] = "Egy páros színház belépő";

			string[] nyertesek = TombolaSorsolas(sorjegyek, nyeremenyek);

			for (int i = 0; i < nyertesek.Length; i++)
			{
				Console.WriteLine(nyertesek[i]);
			}
		}
		#endregion

		#region F02 Kódfejtési Kihívás
		static int[] Kodolas(string szoveg)
		{
			int[] kodtable = new int[szoveg.Length];
			int szamlalo = 0;
			
			foreach (char s in szoveg)
			{
				kodtable[szamlalo] = Convert.ToInt32(s);
				szamlalo++;
			}


			return kodtable;
		}

		static string Dekodolo(int[] kodtabla)
		{
			string ki = "";

			foreach (char s in kodtabla)
			{
				ki += (char)s;
			}

			return ki;
		}

		static void F02()
		{
			string szoveg = "Hello Word";

			int[] kodtable = Kodolas(szoveg);

			string dekodolt = Dekodolo(kodtable);

			Console.WriteLine(dekodolt);
		}
		#endregion

		#region F03 Szótárkezelő program
		static void F03()
		{
			string[] szavak = new string[100];
			string[] magyarázatok = new string[100];
			bool program_fut = true;
			
			while(program_fut)
			{
				Console.WriteLine("Kérem adja meg az utasítást, létező utasítások:\n\tSzó hozzáadása a szótárhoz: 'Add'\n\tSzó keresése a szótárban: 'Keres'\n\tSzó törlése: 'Del'\n\tSzótöredékkel való keresés: 'KeresT'");
				string be = Console.ReadLine();

				switch(be)
				{
					case "Add":
						break;

					default:
						Console.WriteLine("A megadott parancs nem létezik!");
						break;
				}
;			}
		}
		#endregion

		static void Main(string[] args)
		{
			//F01();
			//F02();
			F03();
		}
	}
}
