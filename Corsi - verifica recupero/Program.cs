using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Corsi___verifica_recupero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiarazioni
            int riga, colonna;
            int tartufi;
            int passi = 0;
            int scelta = 0;


            int verticale = 6, orizzontale = 0;
            //ciclo per giocare più volte
            do
            {
                Thread.Sleep(500);
                Console.Clear();
                //input dimensioni della matrice
                Console.WriteLine("Inserire il numeri di colonne: ");
                colonna = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserire il numeri di righe: ");
                riga = Convert.ToInt32(Console.ReadLine());
                //dichiarazione della matrice dopo aver ricevuto i parametri
                int[,] matrice = new int[riga, colonna];
                //input quanti tartufi si vogliono generare
                tartufi = (riga * colonna) / 10;
                //generazionde del campo
                GenerazioneCampo(matrice, riga, colonna, tartufi);
                //stampa del campo
                for (int i = 0; i < riga; i++)
                {
                    for (int z = 0; z < colonna; z++)
                    {
                        //posizionamento del cursore
                        Console.SetCursorPosition(orizzontale, verticale);
                        Console.Write(matrice[i, z]);
                        orizzontale = orizzontale + 5;
                    }
                    //reset della posizione
                    verticale = verticale + 2;
                    orizzontale = 0;
                }
                verticale = 6;

                //richiamo alla funzione per controllare il campo e stamparlo in maniera aggiornata
                int contatore = ControlloCampo(matrice, riga, colonna, tartufi);
                for (int i = 0; i < riga; i++)
                {
                    for (int z = 0; z < colonna; z++)
                    {
                        //posizionamento del cursore
                        Console.SetCursorPosition(orizzontale, verticale);
                        Console.Write(matrice[i, z]);
                        orizzontale = orizzontale + 5;
                    }
                    //reset della posizione
                    verticale = verticale + 2;
                    orizzontale = 0;
                }

                //richiamo alla funzione di movimento
                MovimentoCane(matrice, riga, colonna, contatore, orizzontale, verticale);
                //stampa per far ripetere oppure no il gioco
                Console.WriteLine("\nPremere un numero qualsiasi per giocare di nuovo   - Premere 0 per uscire");
                scelta = Convert.ToInt32(Console.ReadLine());
                verticale = 6;
            } while (scelta != 0);


        }


        //funzione per generare il campo
        static int[,] GenerazioneCampo(int[,] campo, int riga, int colonna, int tartufi)
        {
            //dichiarazioni
            Random r = new Random();
            bool controllo;
            //ciclo per inserire i tartufi in posizione randomica
            for (int z = 0; z < tartufi; z++)
            {
                //ciclo di controllo per verificare che un tartufo non venga posizionata in una posizione già occupata
                do
                {
                    //generazione di indici casuali
                    int N = r.Next(0, riga);
                    int M = r.Next(0, colonna);
                    //controllo posizione vuota
                    if (campo[N, M] == 0)
                    {
                        //se posizione vuota allora true
                        controllo = true;
                        campo[N, M] = 100;
                    }
                    else
                        controllo = false;
                    //genera indici fino a che non si trova una posizione vuota
                } while (controllo == false);
            }
            return campo;
        }

        //funzione di controllo
        static int ControlloCampo(int[,] campo, int riga, int colonna, int tartufi)
        {
            //dichiarazioni
            int contatore = 0;
            int passi = 0;
            for (int i = 0; i < riga; i++)
            {
                for (int z = 0; z < colonna; z++)
                {
                    if (campo[i, z] == 100)
                    {
                        //controllo prima riga della mappa
                        if (i == 0 && z == 0)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //destra
                            if (campo[i, z + 1] != 100)
                                campo[i, z + 1] = campo[i, z + 1] + 1;
                            //basso a destra
                            if (campo[i + 1, z + 1] != 100)
                                campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            if (campo[i + 1, z] != 100)
                                campo[i + 1, z] = campo[i + 1, z] + 1;
                        }
                        else if (i == 0 && z >= 1 && z < colonna - 1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //destra
                            if (campo[i, z + 1] != 0)
                                campo[i, z + 1] = campo[i, z + 1] + 1;
                            //basso a destra
                            if (campo[i + 1, z + 1] != 100)
                                campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            if (campo[i + 1, z] != 100)
                                campo[i + 1, z] = campo[i + 1, z] + 1;
                            //basso a sinistra
                            if (campo[i + 1, z - 1] != 100)
                                campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //sinistra
                            if (campo[i, z - 1] != 100)
                                campo[i, z - 1] = campo[i, z - 1] + 1;
                        }
                        else if (i == 0 && z == colonna - 1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //sinistra
                            if (campo[i, z - 1] != 100)
                                campo[i, z - 1] = campo[i, z - 1] + 1;
                            //basso a sinistra
                            if (campo[i + 1, z - 1] != 100)
                                campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //basso
                            if (campo[i + 1, z] != 100)
                                campo[i + 1, z] = campo[i + 1, z] + 1;
                        }
                        //controllo lati della mappa
                        else if (i >= 1 && i <= riga - 2 && z == 0)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            if (campo[i - 1, z] != 100)
                                campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            if (campo[i - 1, z + 1] != 100)
                                campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            if (campo[i, z + 1] != 100)
                                campo[i, z + 1] = campo[i, z + 1] + 1;
                            //basso a destra
                            if (campo[i + 1, z + 1] != 100)
                                campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            if (campo[i + 1, z] != 100)
                                campo[i + 1, z] = campo[i + 1, z] + 1;
                        }
                        else if (i >= 1 && i <= riga - 2 && z == colonna - 1)
                        {
                            //alto
                            if (campo[i - 1, z] != 100)
                                campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a sinistra
                            if (campo[i - 1, z - 1] != 100)
                                campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                            //sinistra
                            if (campo[i, z - 1] != 100)
                                campo[i, z - 1] = campo[i, z - 1] + 1;
                            //basso a sinistra
                            if (campo[i + 1, z - 1] != 100)
                                campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //basso
                            if (campo[i + 1, z] != 100)
                                campo[i + 1, z] = campo[i + 1, z] + 1;
                        }
                        //controllo ultima riga della mappa
                        else if (i == riga - 1 && z == 0)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            if (campo[i - 1, z] != 100)
                                campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            if (campo[i - 1, z + 1] != 100)
                                campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            if (campo[i, z + 1] != 100)
                                campo[i, z + 1] = campo[i, z + 1] + 1;
                        }
                        else if (i == riga - 1 && z >= 1 && z < colonna - 1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //sinistra
                            if (campo[i, z - 1] != 100)
                                campo[i, z - 1] = campo[i, z - 1] + 1;
                            //alto a sinistra
                            if (campo[i - 1, z - 1] != 100)
                                campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                            //alto
                            if (campo[i - 1, z] != 100)
                                campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            if (campo[i - 1, z + 1] != 100)
                                campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            if (campo[i, z + 1] != 100)
                                campo[i, z + 1] = campo[i, z + 1] + 1;
                        }
                        else if (i == riga - 1 && z == colonna - 1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            if (campo[i - 1, z] != 100)
                                campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a sinistra
                            if (campo[i - 1, z - 1] != 100)
                                campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                            //sinistra
                            if (campo[i, z - 1] != 100)
                                campo[i, z - 1] = campo[i, z - 1] + 1;

                        }
                        //controllo centro della mappa
                        else
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            if (campo[i - 1, z] != 100)
                                campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            if (campo[i - 1, z + 1] != 100)
                                campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            if (campo[i, z + 1] != 100)
                                campo[i, z + 1] = campo[i, z + 1] + 1;
                            if (campo[i + 1, z + 1] != 100)
                                campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            if (campo[i + 1, z] != 100)
                                campo[i + 1, z] = campo[i + 1, z] + 1;
                            //basso a sinistra
                            if (campo[i + 1, z - 1] != 100)
                                campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //sinistra
                            if (campo[i, z - 1] != 100)
                                campo[i, z - 1] = campo[i, z - 1] + 1;
                            //alto a sinistra
                            if (campo[i - 1, z - 1] != 100)
                                campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                        }
                        //contatore per far fermare il ciclo quando il cane avrà trovato tutti i tartufi
                        contatore++;



                    }
                    //se il contatore è uguale al numero di tartufi allora esci dal ciclo
                    if (contatore == tartufi)
                        break;
                    //contatore dei passi, messo dopo la condizione perchè la prima posizione non si condsidera come passo
                    passi++;


                }
            }
            return passi;
        }

        //funzione del movimento del cane
        static void MovimentoCane(int[,] campo, int riga, int colonna, int passi, int PosOr, int PosVe)
        {
            //dichiarazioni
            int orizzontale = 0;
            int verticale = 6;
            int contatore = 0;
            //ciclo di stampa
            for (int i = 0; i < riga; i++)
            {
                for (int z = 0; z < colonna; z++)
                {
                    if (contatore != passi + 1)
                    {
                        //posizionamento del cursore
                        Console.SetCursorPosition(orizzontale, verticale);
                        Thread.Sleep(300);
                        //cambio di colore per stampa
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //stampa del campo aggiornato col passaggio del cane
                        Console.Write(campo[i, z]);
                        orizzontale = orizzontale + 5;
                        contatore++;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //stampa delle informazioni al di sotto del campo di gioco
                        Console.SetCursorPosition(PosOr, PosVe);
                        Console.WriteLine("Passi effettuati dal cane: " + contatore + " ");
                        Console.WriteLine("Valore del riquadro attuale: " + campo[i, z]+" ");
                        Thread.Sleep(350);
                        //stampa per correggere la stampa degli 1 e 100 sovrapposti
                        Console.SetCursorPosition(PosOr, PosVe+1);
                        Console.WriteLine("Valore del riquadro attuale:    ");
                    }

                }
                //reset della posizione
                verticale = verticale + 2;
                orizzontale = 0;
            }

        }
    }
}

    