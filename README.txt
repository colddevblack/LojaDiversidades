
Loja Diversidade Manual
Como executar:
1- configurar solutions para serem todas simultaneamente executadas na solution
LojaDiversidade ir em propriedades:
2-	 por se tratar de um projeto com ORM EntityFrameworkCore, va em Ferramentas > Gerenciador de Pacotes do Nuget > Console do Gerenciador de pacotes
execute os comandos: Add-Migration inicial e depois update-database, para cada projeto ou seja: 
LojaDiversidade.CartApi, LojaDiversidade.DiscountApi, LojaDiversidade.IdentityServer, LojaDiversidade.ProductApi com exceção do LojaDiversidade.Web, que não possui o EntityFrameworkCore
Se já existir pasta Migrations favor excluir antes da execução dos
comandos

No caso da LojaDiversidade.ProductApi será necessário um segundo comando de migration para inclusão de produtos, execute Add-Migration SeedProducts
No arquivo de migrations SeedProducts, inclua o código abaixo para criação de produtos:
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDiversidade.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId) Values('Caderno',7.55,'Caderno Espiral',10,'caderno1.jpg',1)");

            mb.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId) Values('Lápis',3.45,'Lápis Preto',20,'lapis1.jpg',1)");

            mb.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId) Values('Clips',5.33,'Clips para papel',50,'clips1.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
e depois update-database.


3- Logar no sistema após a execução clique no link efetue login ou login
Entre com usuário e senha
Perfil admin para gerenciar o estoque:
User: admin1
Senha: Numsey#2022
Perfil Cliente para efetuar compras:
User: client1
Senha: Numsey#2022
4 – Gerenciar estoque após logar como admin1 clicar em Estoque de Produtos
Nesta tela poderá criar , apagar e atualizar o estoque:
5 –Comprar produtos após logar como client1 clicar em Lista de Ofertas
Selecione o produto desejado:
Adcione ao carrinho com add to cart:
Agora vai no ícone do carrinho na parte superior esquerda
Na tela do carrinho aplique o cupon de desconto exemplo - LojaDiversidade_PROMO_10 e
clique em Checkout:
Na tela de pagamento pode usar os dados fictícios para o pagamento conforme abaixo:

First Name: Elvis
Last Name: Presley
  E-mail:elvis@email.com
  Telephone: 55-98755555
  Card Number:1111111
Name on Card: Elvis Presley
CVV: 1111
Expire Date:0211

LojaDiversidade_PROMO_10


Clique em continue compra efetuada
Composição do projeto:
LojaDiversidade.CartApi – api responsável pelo carrinho de compras
LojaDiversidade.DiscountApi- api responsável pelo cupon de desconto
LojaDiversidade.IdentityServer- api responsável pelos acessos e regras
LojaDiversidade.ProductApi - api responsável pelo estoque, produtos e categorias de produtos
Essas apis podem ser testadas separadamente via swagger conforme exemplo abaixo:
