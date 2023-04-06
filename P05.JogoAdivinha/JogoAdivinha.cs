using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.JogoAdivinha
{
     internal class JogoAdivinha
     {
          public string firula = new string('-', 43);

          public int tentativas = 0, numeroChute = 0, pontuacaoFinal = 1000, pontuacao = 0, numeroAleatorio, nivelDificuldade;


          private void VerificarChute()
          {
               for (int i = 0; i < tentativas; i++)
               {
                    numeroChute = PegarChute(i);

                    if (numeroChute < numeroAleatorio)
                    {
                         pontuacao = ChuteMenor();
                    }

                    if (numeroChute > numeroAleatorio)
                    {
                         pontuacao = ChuteMaior();
                    }

                    if (numeroChute == numeroAleatorio)
                    {
                         AcertouChute();
                         break;
                    }
                    if (i + 1 >= tentativas)
                    {
                         AcabouTentativas();
                         break;
                    }
               }
          }

          private void AcabouTentativas()
          {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Acabaram suas tentativas!");
               Console.ResetColor();
          }

          private void AcertouChute()
          {
               Console.WriteLine("Parabéns, você acertou!");
               Console.WriteLine($"\nPontuação final é de {pontuacaoFinal}!");
          }

          private int ChuteMaior()
          {
               int pontuacao = Math.Abs((numeroChute - numeroAleatorio) / 2);
               pontuacaoFinal = pontuacaoFinal - pontuacao;
               Console.WriteLine("Seu chute foi maior que o número secreto!");
               Console.WriteLine($"Você fez {pontuacaoFinal} pontos!");
               Console.ReadLine();
               return pontuacao;
          }

          private int ChuteMenor()
          {
               int pontuacao = Math.Abs((numeroChute - numeroAleatorio) / 2);
               pontuacaoFinal = pontuacaoFinal - pontuacao;

               Console.WriteLine("Seu chute foi menor que o número secreto!");
               Console.WriteLine($"Você fez {pontuacaoFinal} pontos!");
               Console.ReadLine();
               return pontuacao;
          }

          private int PegarChute(int i)
          {
               int numeroChute;
               Console.Clear();
               Console.WriteLine($"\nTentativa {i + 1} de {tentativas}\n");
               Console.WriteLine(firula);

               numeroChute = PegarValor($"\nQual o seu {i + 1}º chute? ");
               return numeroChute;
          }

          private int PegarValor(string mensagem)
          {
               Console.Write(mensagem);
               int valor = Convert.ToInt32(Console.ReadLine());
               return valor;
          }

          public void GerarJogoAdivinha()
          {
               nivelDificuldade = PegarValor("\nEscolha:\n> ");
               switch (nivelDificuldade)
               {
                    case 1:
                         tentativas = 15;

                         VerificarChute();

                         break;

                    case 2:
                         tentativas = 10;

                         VerificarChute();

                         break;

                    case 3:
                         tentativas = 5;

                         VerificarChute();

                         break;
               }
          }
     }
}
