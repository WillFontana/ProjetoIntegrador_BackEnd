# ProjetoIntegrador_BackEnd

Projeto Integrador Faculdade Positivo
Back end do sistema

## Dependências necessárias:

AutoMapper.Extensions.Microsoft.DependencyInjection __(versão 8.1.1)__
Microsoft.AspNetCore.Mvc.Formatters.Json __(versão 2.2.0)__
Microsoft.AspNetCore.Mvc.NewtonsoftJson __(versão 5.0.7)__
Microsoft.EntityFrameworkCore __(versão 5.0.5)__
Microsoft.EntityFrameworkCore.Proxies __(versão 5.0.5)__
Microsoft.EntityFrameworkCore.SqlServer __(versão 5.0.5)__
Microsoft.EntityFrameworkCore.Tools __(versão 5.0.5)v
MySql.EntityFrameworkCore __(versão 5.0.3)__
Newtonsoft.Json __(versão 13.0.1)__
Swashbuckle.AspNetCore __(versão 6.2.2)__

### Fluxo de desenvolvimento:

Focar no desenvolvimento de apenas uma entidade por vez, por exemplo, caso esteja desenvolvendo a entidade _clientes_, finalizar sua _model_, suas _DTO's_, adicionar sua _Profile_, sua _Controler_ e por fim adicionar a mesma no contexto principal _(MainContext)_
Após o desenvolvimento, antes de enviar para o git, realizar o teste da migration.

### Teste da migration:

Na barra de pesquisa do Visual Studio (ou ctrl + q), pesquisar por _Console de Gerenciador de Pacotes_, o mesmo irá abrir um console do tipo shell no Visual Studio, então, rodar o comando _Add-Migration_, e aguardar o build, se ocorrer sucesso, rodar o comando _Update-Database_ e aguardar a execução do mesmo.
Caso tudo ocorra sem erros realizar o fluxo do git, senão procurar e corrigir o erro.

### Fluxo do git:

Como o projeto possui diversas pessoas trabalhando ao mesmo tempo, é sempre importante mandar apenas os _arquivos que você alterou ou adicionou_, evitando assim o conflito de arquivos gerados automaticamente pela máquina.
Para isso os comandos devem ser mais ou menos assim:

> git pull

> git add "nome_do_arquivo.extensao_do_arquivo"
ou
> git add .\nome_da_pasta\nome_da_subpasta\

> git commit -m "Descrição do que fez"

> git push