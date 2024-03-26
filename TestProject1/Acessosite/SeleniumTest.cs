using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.Overlay;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestProject1.Acessosite.SeleniumTest;

namespace TestProject1.Acessosite
{
    internal class SeleniumTest
    {
        [Test]
        public void Acessosite()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.br");

            Assert.That(driver.Title, Is.EqualTo("Google"));

            driver.Quit();
        }
        [Test]
        public void TesteAcessourlesperada()
        {

            IWebDriver driver = new ChromeDriver();


            // string url = "https://www.google.com.br";


            //string linkEsperado = "https://www.google.com.br";

            try
            {
                // URL esperada
                string urlEsperada = "https://www.google.com.br";

                // Navegar até a URL desejada
                driver.Navigate().GoToUrl(urlEsperada);

                // Capturar a URL atual após a navegação
                string urlAtual = driver.Url;

                // Verificar se a URL atual corresponde à URL esperada
                if (urlAtual == urlEsperada)
                {
                    Console.WriteLine("A URL digitada é a mesma que a esperada!");
                }
                else
                {
                    Console.WriteLine("A URL digitada não é a mesma que a esperada.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocorreu um erro ao navegar para a URL:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Threading.Thread.Sleep(5000);
                driver.Quit();
            }

        }
        [Test]
        public void TestePesquisa()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com");

            IWebElement campoDeBusca = driver.FindElement(By.Id("APjFqb"));

            campoDeBusca.SendKeys("Amazon");

            campoDeBusca.SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(5000);

            IWebElement resultados = driver.FindElement(By.Id("APjFqb"));

            Assert.IsTrue(resultados.Displayed, "Os resultados da pesquisa não foram exibidos corretamente.");

            driver.Quit();
        }

        [Test]
        public void TesteLogin()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            IWebElement campoUsuario = driver.FindElement(By.XPath("//input[@id='username']"));
            campoUsuario.SendKeys("tomsmith");

            System.Threading.Thread.Sleep(500);

            IWebElement campoSenha = driver.FindElement(By.XPath("//input[@id='password']"));
            campoSenha.SendKeys("SuperSecretPassword!");

            IWebElement botaoProximaSenha = driver.FindElement(By.CssSelector(".fa.fa-2x.fa-sign-in"));
            botaoProximaSenha.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement botaoLogout = driver.FindElement(By.CssSelector(".icon-2x.icon-signout"));

            Assert.IsTrue(botaoLogout.Displayed, "O login não foi realizado com sucesso.");

            driver.Quit();
        }
        [Test]
        public void TesteLoginInsucesso()

        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            try
            {

                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

                IWebElement campoUsuario = driver.FindElement(By.XPath("//input[@id='username']"));
                campoUsuario.SendKeys("tomsmith");

                IWebElement campoSenha = driver.FindElement(By.XPath("//input[@id='password']"));
                campoSenha.SendKeys("SuperSecretPassword");

                IWebElement botaoLogin = driver.FindElement(By.CssSelector(".fa.fa-2x.fa-sign-in"));
                botaoLogin.Click();

                // Verificar se a mensagem de erro é exibida
                IWebElement mensagemErro = driver.FindElement(By.XPath("//div[@id='flash']"));
                Assert.That(mensagemErro.Text, Is.EqualTo("Your password is invalid!\r\n×"));

                Console.WriteLine("Teste de login com falha concluído com sucesso.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Elemento não encontrado. Verifique os seletores CSS ou IDs.");
                Assert.Fail("Elemento não encontrado. Verifique os seletores CSS ou IDs.");
            }
            catch (AssertionException ex)
            {
                Console.WriteLine("A mensagem de erro não corresponde à esperada.");
                Assert.Fail($"A mensagem de erro não corresponde à esperada: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção inesperada: {ex.Message}");
                Assert.Fail($"Ocorreu uma exceção inesperada: {ex.Message}");
            }
            System.Threading.Thread.Sleep(500);
            driver.Quit();

        }
        [Test]
        public void MultiplassAçõesNav()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.amazon.com.br");

            // Aguardar um tempo para visualização (opcional)
            //System.Threading.Thread.Sleep(100);

            IWebElement produto = driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));
            produto.SendKeys("Iphone 14");
            produto.SendKeys(Keys.Enter);

            IWebElement botaoSendEmail = driver.FindElement(By.XPath("//img[@alt='Anúncio patrocinado – Apple iPhone 15 (512 GB) — Azul']"));
            botaoSendEmail.Click();

            // Aguardar um tempo para visualização (opcional)
            System.Threading.Thread.Sleep(100);

            IWebElement campoCor = driver.FindElement(By.XPath("//img[@alt='Preto']"));
            campoCor.Click();

            IWebElement campoConfi = driver.FindElement(By.XPath("//p[normalize-space()='15 Plus']"));
            campoConfi.Click();

            //IWebElement botaoBoleto = driver.FindElement(By.Id("pp-PXAc2L-241")); // Substitua pelo ID real do botão "Adicionar ao Carrinho"
            //botaoBoleto.Click();
            System.Threading.Thread.Sleep(500);
            driver.Quit();

        }

        [Test]
        public void TesteDropDown()

        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

            IWebElement dropDownList = driver.FindElement(By.Id("dropdown"));

            // Criar um objeto SelectElement
            SelectElement select = new SelectElement(dropDownList);

            select.SelectByText("Option 1");

            System.Threading.Thread.Sleep(500);
            driver.Quit();
        }
        [Test]
        public void TesteBotaoStart()

        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");

            IWebElement dropDownList = driver.FindElement(By.CssSelector("div[id='start'] button"));
            dropDownList.Click();
            System.Threading.Thread.Sleep(5000);

            IWebElement helloWorldMessage = driver.FindElement(By.CssSelector("div[id='finish'] h4"));
            System.Threading.Thread.Sleep(1000);

            var element = driver.FindElement(By.XPath("//h4[normalize-space()='Hello World!']"));
            if (!string.IsNullOrEmpty(element.Text) && element.Text.Contains("Hello World!"))

                System.Threading.Thread.Sleep(500);
            driver.Quit();
        }
        [Test]
        public void TesteBotaoStart2()

        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");

            IWebElement dropDownList = driver.FindElement(By.CssSelector("div[id='start'] button"));
            dropDownList.Click();
            System.Threading.Thread.Sleep(5000);

            IWebElement helloWorldMessage = driver.FindElement(By.CssSelector("div[id='finish'] h4"));
            System.Threading.Thread.Sleep(1000);

            var element = driver.FindElement(By.XPath("//h4[normalize-space()='Hello World!']"));
            if (!string.IsNullOrEmpty(element.Text) && element.Text.Contains("Hello World!"))

            System.Threading.Thread.Sleep(500);
            driver.Quit();
        }

        //1º slide com atividade

        [Test]
        public void TesteAsserções()

        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public class Produto
        {
            public required string Nome { get; set; }
            public decimal Valor { get; set; }
        }

    }

        public class ProdutoTest
    {
        public class Produto
        {
            public required string Nome { get; set; }
            public decimal Valor { get; set; }
        }

        public class ProdutoUtils
        {
         
            public bool CompararProdutos(Produto produto1, Produto produto2)
            {
                return produto1.Nome == produto2.Nome && produto1.Valor == produto2.Valor;
            }
        }

            public void TestCompararProdutos()
            {
                WebDriver driver = new ChromeDriver();
                Produto produto1 = new Produto { Nome = "Produto A", Valor = 50 };
                Produto produto2 = new Produto { Nome = "Produto A", Valor = 50 };
                
                ProdutoUtils produtoUtils = new ProdutoUtils();

                bool produtosIguais = produtoUtils.CompararProdutos(produto1, produto2);

                Assert.IsTrue(produtosIguais, "Os produtos não são iguais.");

            }
        [Test]
        public void TesteCompararStrings()
        {
         
            string string1 = "Hello World!";
            string string2 = "Olá Mundo!";

            Assert.IsFalse(string1 == string2, "As strings contêm os mesmos caracteres.");
        }
        [Test]
        public void TestCompararStrings()
        {
            string resultadoObtido = "Hello World!";
            string resultadoEsperado = "Hello World!";

            Assert.That(resultadoObtido, Is.EqualTo(resultadoEsperado), "O resultado obtido não é igual ao resultado esperado.");
        }
    }
}
    

    
           
    
    
    


    

        