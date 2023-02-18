
#Componentes instalados
<pre>
	dotnet add package Microsoft.EntityFrameworkCore --version 7.0.3
	dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.3
	dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.3
	dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
	dotnet add package Microsoft.EntityFrameworkCore.Relational --version 7.0.3

	dotnet tool install --global dotnet-ef
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