namespace P05.JogoAdivinha
{
     internal class Program
     {
          static void Main(string[] args)
          {
               Random aleatorio = new Random();

               do
               {
                    string firula = new string('-', 43);

                    int numeroAleatorio = aleatorio.Next(1, 20);

                    string opcao = GerarMenu();

                    if (opcao == "S")
                    {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("\nSaindo...");
                         Console.ResetColor();
                         break;
                    }

                    int tentativas = 0, numeroChute = 0;
                    int pontuacao = 0;
                    int pontuacaoFinal = 1000;

                    Console.WriteLine("\nEscolha o nível de dificuldade");
                    Console.WriteLine("\n(1) Fácil (2) Médio (3) Difícil");

                    int nivelDificuldade = PegarValor("\nEscolha:\n> ");

                    switch (nivelDificuldade)
                    {
                         case 1:
                              tentativas = 15;

                              VerificarChute(firula, numeroAleatorio, tentativas, ref numeroChute, ref pontuacao, ref pontuacaoFinal);

                              break;

                         case 2:
                              tentativas = 10;

                              VerificarChute(firula, numeroAleatorio, tentativas, ref numeroChute, ref pontuacao, ref pontuacaoFinal);

                              break;

                         case 3:
                              tentativas = 5;

                              VerificarChute(firula, numeroAleatorio, tentativas, ref numeroChute, ref pontuacao, ref pontuacaoFinal);

                              break;
                    }
                    Console.ReadLine();

               } while (true);

          }

          #region Funçõees;
          private static void VerificarChute(string firula, int numeroAleatorio, int tentativas, ref int numeroChute, ref int pontuacao, ref int pontuacaoFinal)
          {
               for (int i = 0; i < tentativas; i++)
               {
                    numeroChute = PegarChute(firula, tentativas, i);

                    if (numeroChute < numeroAleatorio)
                    {
                         pontuacao = ChuteMenor(numeroAleatorio, numeroChute, ref pontuacaoFinal);
                    }

                    if (numeroChute > numeroAleatorio)
                    {
                         pontuacao = ChuteMaior(numeroAleatorio, numeroChute, ref pontuacaoFinal);
                    }

                    if (numeroChute == numeroAleatorio)
                    {
                         AcertouChute(pontuacaoFinal);
                         break;
                    }
                    if (i + 1 >= tentativas)
                    {
                         AcabouTentativas();
                         break;
                    }
               }
          }

          private static void AcabouTentativas()
          {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Acabaram suas tentativas!");
               Console.ResetColor();
               Console.ReadLine();
          }

          private static void AcertouChute(int pontuacaoFinal)
          {
               Console.WriteLine("Parabéns, você acertou!");
               Console.WriteLine($"\nPontuação final é de {pontuacaoFinal}!");
          }

          private static int ChuteMaior(int numeroAleatorio, int numeroChute, ref int pontuacaoFinal)
          {
               int pontuacao = Math.Abs((numeroChute - numeroAleatorio) / 2);
               pontuacaoFinal = pontuacaoFinal - pontuacao;
               Console.WriteLine("Seu chute foi maior que o número secreto!");
               Console.WriteLine($"Você fez {pontuacaoFinal} pontos!");
               Console.ReadLine();
               return pontuacao;
          }

          private static int ChuteMenor(int numeroAleatorio, int numeroChute, ref int pontuacaoFinal)
          {
               int pontuacao = Math.Abs((numeroChute - numeroAleatorio) / 2);
               pontuacaoFinal = pontuacaoFinal - pontuacao;

               Console.WriteLine("Seu chute foi menor que o número secreto!");
               Console.WriteLine($"Você fez {pontuacaoFinal} pontos!");
               Console.ReadLine();
               return pontuacao;
          }

          private static int PegarChute(string firula, int tentativas, int i)
          {
               int numeroChute;
               Console.Clear();
               Console.WriteLine($"\nTentativa {i + 1} de {tentativas}\n");
               Console.WriteLine(firula);

               numeroChute = PegarValor($"\nQual o seu {i + 1}º chute? ");
               return numeroChute;
          }

          private static string GerarMenu()
          {
               Console.Clear();
               Console.WriteLine("===============================");
               Console.WriteLine("\nJogo da Adivinhação!\n");
               Console.WriteLine("===============================");

               Console.Write("\nDigite S para sair, ou qualquer outro botão para continuar:\n> ");

               string opcao;
               opcao = Console.ReadLine().ToUpper();
               return opcao;
          }

          private static int PegarValor(string mensagem)
          {
               Console.Write(mensagem);
               int valor = Convert.ToInt32(Console.ReadLine());
               return valor;
          }

          #endregion
     }
}