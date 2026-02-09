using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
					bool fut = true;
					int szamlalo = 0;
					while(fut)
					{
						if (seged[szamlalo] == nyertes)
						{
							szerepel = true;
							fut = false;
						}
						szamlalo++;
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
		static string[] szavak = new string[100];
		static string[] magyarazatok = new string[100];
		static bool Tele()
		{
			int hossz = 0;
			foreach (var item in szavak)
			{
				if (item != "")
				{
					hossz++;
				}
			}

			if(hossz> szavak.Length)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		static void SzotarHozzaad(string[] szavak, string[] magyarazatok)
		{
			Console.Write("Adja meg az új szót: ");
			string szo = Console.ReadLine();
			szo.ToLower();

			Console.Write("Adja meg az új szó magyarázattát: ");
			string magy = Console.ReadLine();

			if (Tele())
			{
				if (szavak.Contains(szo))
				{
					Console.WriteLine($"A megadott szó {szo} már szerepel a szótárban!");
				}
				else
				{
					int index = 0;
					while(szavak[index] != "")
					{
						index++;
					}
					szavak[index] = szo;
					magyarazatok[index] = magy;
					Console.WriteLine($"A {szo} sikeresen hozzá let adva a szótáthoz!");
				}
			}
			else
			{
				Console.WriteLine("A szótár tele van, töröni kell hogy új elemet adhasunk meg!");
			}
		}
		static void KeresSzotarban(string[] szavak, string[] magyarazatok)
		{
			Console.Write("Kérem adja meg a kereset szót: ");
			string szo = Console.ReadLine();
			szo.ToLower();

			int kereset = Array.IndexOf(szavak, szo);

			if (kereset != -1)
			{
				Console.WriteLine($"{szo} magyarázata: {magyarazatok[kereset]}");
			}
			else
			{
				Console.Write($"{szo} nem szerepel a szótárban.");
			}
		}
		static void SzotarbolTorol(string[] szavak, string[] magyarazatok)
		{
			Console.Write("Kérem adja meg a törölni kivánt szót: ");
			string szo = Console.ReadLine();
			szo.ToLower();

			int kereset = Array.IndexOf(szavak, szo);

			if (kereset != -1)
			{
				szavak[kereset] = "";
				magyarazatok[kereset] = "";
			}
			else
			{
				Console.Write($"{szo} nem szerepel a szótárban.");
			}
		}
		static void KeresSzooredekAlajan(string[] szavak, string[] magyarazatok)
		{
			Console.Write("Kérem adja meg a kereset szót töredéket: ");
			string szotor = Console.ReadLine();
			szotor.ToLower();

			foreach (var item in szavak)
			{
				if (item.Contains(szotor))
				{
					Console.WriteLine(item);
				}
			}
		}
		static void F03(string[] szavak, string[] magyarazatok)
		{
			bool program_fut = true;
			
			while(program_fut)
			{
				Console.WriteLine("Kérem adja meg az utasítást, létező utasítások:\n\tSzó hozzáadása a szótárhoz: 'Add'\n\tSzó keresése a szótárban: 'Keres'\n\tSzó törlése: 'Del'\n\tSzótöredékkel való keresés: 'KeresT'\n\tHa ki szeretne lépni: 'Exit'");
				string be = Console.ReadLine();
				be.ToLower();
				switch(be)
				{
					case "add":
						SzotarHozzaad(szavak, magyarazatok);
						break;

					case "keres":
						KeresSzotarban(szavak, magyarazatok);
						break;

					case "del":
						SzotarbolTorol(szavak, magyarazatok);
						break;

					case "kerest":
						KeresSzooredekAlajan(szavak, magyarazatok);
						break;

					case "exit":
						Console.WriteLine("kilépés...");
						program_fut = false;
						break;

					default:
						Console.WriteLine("A megadott parancs nem létezik!");
						break;
				}
;			}
		}
		#endregion

		#region F04 Akasztófa
		static void F04()
		{
			string[] sorok = new string[6];
			Console.WriteLine(sorok[0]);
			Console.WriteLine(sorok[1]);
			Console.WriteLine(sorok[2]);
			Console.WriteLine(sorok[3]);
			Console.WriteLine(sorok[4]);
			Console.WriteLine(sorok[5]);


		}
		#endregion

		static void Main(string[] args)
		{
			F01();
			F02();
			//F03(szavak, magyarazatok);
			F04();
		}
	}
}
