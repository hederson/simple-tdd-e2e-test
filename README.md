# Api simples para validação de senhas
### Execução e testes

Para executar api execute os comandos na raiz da solution

```console
dotnet build
dotnet run --project SimplePasswordCheck
```

Para executar os testes unitários e de integração execute o comando abaixo

```console
dotnet test
```

### Considerações

Foi utilizado o basico de Solid/DDD fiz todo o código dentro do projeto da API pois como era um exemplo muito simples não tinha necessidade de criar varios projetos.

Foram feitas duas versões da validação de senha, uma utilizando Linq e outra Regex, a principio eu já desconfiava que a solução com Regex ficaria mais lenta, porem resolvi fazer o benchmark para validar.
Em geral a versão utilizando Linq teve um desempenho melhor, como demonstrado no resultado, então ela foi utilizada na versão final da api.

Para realizar o benchmark basta executar o comando abaixo.

```console
dotnet build
dotnet run --project SimplePasswordCheck.Benchmark -c Release
```

### Resultado Benchmark

```console
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.200
  [Host]     : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT


|                Method |       password |         Mean |      Error |      StdDev |
|---------------------- |--------------- |-------------:|-----------:|------------:|
|  ValidatePasswordLinq |       AAAbbbCc |    53.445 ns |  0.9699 ns |   0.8598 ns |
| ValidatePasswordRegex |       AAAbbbCc |     4.232 ns |  0.1175 ns |   0.1399 ns |
|  ValidatePasswordLinq |      AbTp9 fok |   663.666 ns | 13.0295 ns |  11.5503 ns |
| ValidatePasswordRegex |      AbTp9 fok | 1,935.615 ns | 38.5541 ns |  78.7558 ns |
|  ValidatePasswordLinq |   AbTp9!fek123 | 1,921.506 ns | 30.6722 ns |  27.1901 ns |
| ValidatePasswordRegex |   AbTp9!fek123 | 3,499.152 ns | 69.4635 ns | 112.1705 ns |
|  ValidatePasswordLinq | AbTp9!fek123() | 2,370.245 ns | 46.3247 ns |  51.4898 ns |
| ValidatePasswordRegex | AbTp9!fek123() | 4,512.653 ns | 89.6386 ns | 156.9948 ns |
|  ValidatePasswordLinq |  AbTp9!fek123) | 2,151.298 ns | 42.3510 ns |  52.0108 ns |
| ValidatePasswordRegex |  AbTp9!fek123) | 4,018.478 ns | 79.1472 ns | 120.8661 ns |
|  ValidatePasswordLinq |     AbTp9!feka | 1,516.503 ns | 15.9888 ns |  14.9560 ns |
| ValidatePasswordRegex |     AbTp9!feka | 2,646.062 ns | 51.8650 ns |  79.2034 ns |
|  ValidatePasswordLinq |      AbTp9!foA |   177.405 ns |  3.5576 ns |   4.8696 ns |
| ValidatePasswordRegex |      AbTp9!foA |   312.091 ns |  6.1687 ns |  10.1354 ns |
|  ValidatePasswordLinq |      AbTp9!fok | 1,228.805 ns | 24.5971 ns |  38.2947 ns |
| ValidatePasswordRegex |      AbTp9!fok | 2,333.691 ns | 46.5057 ns | 105.9170 ns |
|  ValidatePasswordLinq |      AbTp9!foo |   868.713 ns | 15.6563 ns |  14.6449 ns |
| ValidatePasswordRegex |      AbTp9!foo | 2,548.414 ns | 50.5260 ns |  93.6532 ns |
``` 