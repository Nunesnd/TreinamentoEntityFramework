
#Componentes instalados
<pre>
	dotnet add package Microsoft.EntityFrameworkCore --version 7.0.3
	dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.3
	dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.3
	dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
	dotnet add package Microsoft.EntityFrameworkCore.Relational --version 7.0.3
	dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.12
	dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.3

	dotnet aspnet-codegenerator controller -name ClientesController -m ClienteModel -dc DbContexto --relativeFolderPath Controllers --useDefaultLayout


	dotnet tool install --global dotnet-ef
</pre>

#Instalação do Code Generator
<pre>
dotnet new tool-manifest # if you are setting up this repo
dotnet tool install --local dotnet-aspnet-codegenerator --version 6.0.12
</pre>

#.gitignore
<pre>
	#componentes configurados para serem ignorados:

	ASPNETCore
	Csharp
	DotnetCore
	Linux
	macOS
	Windows
	VisualStudio
	VisualStudioCode

</pre>

#Comandos para migração
<pre>

dotnet-ef migration add ClienteAdd
</pre>


#Conexçao com o banco e dados
<pre>
Faça uma cópia do arquivo asssettings.Development.json com o nome asssettings.json.
Dentro dele defina o nome do banco de dados Mysql, o usuário Admin e senha.
No .gitignore este arquivo não será commitado.
</pre>