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
					while(fut && szamlalo < 5)
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

			for (int i = 0; i < kodtable.Length; i++)
			{
				Console.Write($"{kodtable[i]} ");
			}
            Console.WriteLine();
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
			Random rnd = new Random();
            string[] kirajzolas = new string[6];

            string[] rajz = new string[15];
			rajz[14] = "/";
			rajz[13] = "-";
			rajz[12] = "\\";
			rajz[11] = " |";
			rajz[10] = " |     ";
            rajz[9] = " |     ";
            rajz[8] = " |      ";
            rajz[7] = " |";
			rajz[6] = "------|";
            rajz[5] = "o";
            rajz[4] = "/";
            rajz[3] = "|";
            rajz[2] = "\\";
			rajz[1] = "/ ";
			rajz[0] = "\\";

			string[] szavak = new string[10];
			szavak[0] = "tehén";
			szavak[1] = "teve";
			szavak[2] = "bálna";
			szavak[3] = "tigris";
            szavak[4] = "giráf";
            szavak[5] = "elefánt";
            szavak[6] = "kengorú";
            szavak[7] = "hiéna";
            szavak[8] = "leopárd";
            szavak[9] = "vidra";

			bool jatek = true;
			int tippek_szama = 15;
			bool nyert = false;

            string kereset_szo = szavak[rnd.Next(0, szavak.Length)];
            char[] epulo_szo = new char[kereset_szo.Length];
			for (int i = 0; i < kereset_szo.Length; i++)
			{
				epulo_szo[i] = '_';
			}

			string hibas_talalatok = "";

            while (jatek)
			{
                Console.Clear();
                Console.WriteLine("Akasztófa jaték!");
                Console.WriteLine($"Találd ki a szót amire gonolt a játék {rajz.Length} tippből hogy nyerj!");
                Console.WriteLine();

                Console.WriteLine(kirajzolas[0]);
                Console.WriteLine(kirajzolas[1]);
                Console.WriteLine(kirajzolas[2]);
                Console.WriteLine(kirajzolas[3]);
                Console.WriteLine(kirajzolas[4]);
                Console.WriteLine(kirajzolas[5]);
                Console.WriteLine();

                if (kereset_szo == new string(epulo_szo))
                {
                    jatek = false;
                    nyert = true;
                    Console.WriteLine($"Gratulálunk nyertél, a szó '{kereset_szo}' volt!");
                }

                if (tippek_szama == 0 && !nyert)
                {
                    jatek = false;
                    Console.WriteLine($"Vesztetél, a szó '{kereset_szo}' volt!");
                }

				if (jatek && !nyert)
				{
					Console.Write($"A szó: '");
					for (int i = 0; i < epulo_szo.Length; i++)
					{
						Console.Write(epulo_szo[i]);
					}
					Console.WriteLine($"', rendelkezésre állő hibás tippek: {tippek_szama}");
					Console.WriteLine($"Hibás találatok: {hibas_talalatok}");
					Console.Write("Adj meg egy betűt: ");
					string be = Console.ReadLine();
					be.ToLower();
					char tipp = be[0];


					if (kereset_szo.Contains(tipp))
					{
						for (int i = 0; i < kereset_szo.Length; i++)
						{
							if (kereset_szo[i] == tipp)
							{
								epulo_szo[i] = tipp;
							}
						}
						Console.WriteLine($"Helyes találat, a(z) '{tipp}' szerep a szóban!");
						Console.WriteLine();
					}
					else
					{
						Console.WriteLine($"A tipp helytelen, a(z) '{tipp}' nem szerep a szóban!");
						Console.WriteLine();
						hibas_talalatok += tipp + ", ";
						tippek_szama--;

						switch (tippek_szama)
						{
							case 0:
								kirajzolas[3] += rajz[0];
								break;
							case 1:
								kirajzolas[3] += rajz[1];
								break;

							case 2:
								kirajzolas[2] += rajz[2];
								break;

							case 3:
								kirajzolas[2] += rajz[3];
								break;

							case 4:
								kirajzolas[2] += rajz[4];
								break;

							case 5:
								kirajzolas[1] += rajz[5];
								break;

							case 6:
								kirajzolas[0] += rajz[6];
								break;

							case 7:
								kirajzolas[0] += rajz[7];
								break;

							case 8:
								kirajzolas[1] += rajz[8];
								break;

							case 9:
								kirajzolas[2] += rajz[9];
								break;

							case 10:
								kirajzolas[3] += rajz[10];
								break;

							case 11:
								kirajzolas[4] += rajz[11];
								break;

							case 12:
								kirajzolas[5] += rajz[12];
								break;

							case 13:
								kirajzolas[5] += rajz[13];
								break;

							case 14:
								kirajzolas[5] += rajz[14];
								break;

							default:
								break;
						}
					}
				}
			}

		}
		#endregion

		static void Main(string[] args)
		{
			//F01();
            Console.WriteLine();
			//F02();
            Console.WriteLine();
			//F03(szavak, magyarazatok);
            Console.WriteLine();
			F04();

			Console.ReadKey();
		}
	}
}
