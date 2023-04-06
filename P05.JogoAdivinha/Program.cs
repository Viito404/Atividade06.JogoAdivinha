namespace P05.JogoAdivinha
{
     internal class Program
     {
          static void Main(string[] args)
          {
               do
               {
                    JogoAdivinha jogo1 = new JogoAdivinha();
                    Random aleatorio = new Random();
                    jogo1.numeroAleatorio = aleatorio.Next(1, 20);
                    GerarMenu();
                    jogo1.GerarJogoAdivinha();
                    Console.ReadLine();

               } while (true);
          }
          private static void GerarMenu()
          {
               Console.Clear();
               Console.WriteLine("===============================");
               Console.WriteLine("\nJogo da Adivinhação!\n");
               Console.WriteLine("===============================");

               Console.Write("\nDigite S para sair, ou qualquer outro botão para continuar:\n> ");

               string opcao;
               opcao = Console.ReadLine().ToUpper();

               if (opcao == "S")
               {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSaindo...");
                    Console.ResetColor();
                    Environment.Exit(0);
               }
                    Console.WriteLine("\nEscolha o nível de dificuldade");
                    Console.WriteLine("\n(1) Fácil (2) Médio (3) Difícil");
          }
     }
}