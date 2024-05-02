using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisLight.Lampada
{
    public class LampadaController
    {
        private static int ultimoCodigo = 0;
        
        public static List<Lampada> Lampadas = new();
        
        public static void ConsultarPotencia()
        {
            int soma = 0;
            int count = 0;
            foreach (var lampada in Lampadas)
            {
                if (lampada.Acesa == true)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine("Codigo da Lâmpada: " + lampada.Codigo);
                    Console.WriteLine("Status da Lâmpada: Ligada");
                    Console.WriteLine("Potência da Lâmpada: " + lampada.Potencia);

                    soma += lampada.Potencia;
                    count++;
                }
                else
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine("Codigo da Lâmpada: " + lampada.Codigo);
                    Console.WriteLine("Status da Lâmpada: Desligada");
                    Console.WriteLine("Potência da Lâmpada: " + lampada.Potencia);
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"Não existem lâmpadas acesas");
            }
            else
            {
                Console.WriteLine("==========================");
                Console.WriteLine($"Existem {count} lâmpadas acesas, com a potência total de {soma}W");
            }
        }
        public static void CadastrarLampada()
        {
            for (int i = 0; i < 5; i++)
            {
                Lampada lampada = new()
                {
                    Codigo = ultimoCodigo,
                };
                Console.WriteLine("Codigo da lampada: " + lampada.Codigo);
                Console.WriteLine("Situação da lâmpada: Desligada");
                try
                {
                    Console.WriteLine("Qual a potência da lâmpada? ");
                    int potencia = Convert.ToInt32(Console.ReadLine());
                    lampada.Potencia = potencia;
                    Console.WriteLine("Lâmpada criada com Sucesso");
                    Console.WriteLine("==========================");
                    Lampadas.Add(lampada);
                    ultimoCodigo++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor de potência válido");
                    throw;
                }
            }
        }
        public static void LigarLampada()
        {
            try
            {
                if (Lampadas.Count > 0)
                {
                    Console.WriteLine("Insira o código da lâmpada que deseja ligar: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    foreach (var lampada in Lampadas)
                    {
                        if (lampada.Codigo == codigo && lampada.Acesa == false)
                        {
                            lampada.Acesa = true;
                            Console.WriteLine($"Lâmpada de código {lampada.Codigo} ligada com sucesso!");
                            Console.WriteLine("==========================");
                        }
                        else if (lampada.Codigo == codigo && lampada.Acesa == true)
                        {
                            Console.WriteLine($"Lâmpada de código {lampada.Codigo} já está ligada!");
                            Console.WriteLine("==========================");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Não existem lâmpadas cadastradas.");
                }
            }
            catch (Exception)
            {

                Console.WriteLine($"Insira um código válido!");
            }

        }
        public static void DesligarLampada()
        {
            try
            {
                if (Lampadas.Count > 0)
                {
                    Console.WriteLine("Insira o código da lâmpada que deseja desligar: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    foreach (var lampada in Lampadas)
                    {
                        if (lampada.Codigo == codigo && lampada.Acesa == true)
                        {
                            lampada.Acesa = false;
                            Console.WriteLine($"Lâmpada de código {lampada.Codigo} desligada com sucesso!");
                            Console.WriteLine("==========================");
                        }
                        else if (lampada.Codigo == codigo && lampada.Acesa == false)
                        {
                            Console.WriteLine($"Lâmpada de código {lampada.Codigo} já está desligada!");
                            Console.WriteLine("==========================");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Não existem lâmpadas cadastradas.");
                }
            }
            catch (Exception)
            {

                Console.WriteLine($"Insira um código válido!");
            }

        }
        public static void MenuLampada()
        {
            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("1 – Cadastrar lâmpadas\r\n2 – Ligar lâmpada\r\n3 – Desligar lâmpada\r\n4 – Consultar potência utilizada\r\n5 – Sair");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        CadastrarLampada();
                        break;
                    case 2:
                        LigarLampada();
                        break;
                    case 3:
                        DesligarLampada();
                        break;
                    case 4:
                        ConsultarPotencia();
                        break;
                    case 5:
                        Console.WriteLine("Operação finalizada!");
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
