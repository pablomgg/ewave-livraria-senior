namespace ToDo.Dapper.Queries
{
    public struct EmprestimoQueries
    {
        public const string Query = @"
                                    SELECT 
                                         [emp].[AggregateId]
                                        ,[emp].[DataEmprestimo]
                                        ,[emp].[DataVencimento]
                                        ,[emp].[DataDevolucao]
                                        ,[emp].[Ativo]
                                        ,[emp].[UsuarioId]
                                        ,[li].[Titulo]
                                        ,[emp].[LivroId]
                                        ,[pf].[Nome]
                                    FROM [ToDo].[dbo].[Emprestimo] AS [emp]
                                        INNER JOIN [ToDo].[dbo].[Usuario] AS [usu] ON [usu].[Id] = [emp].[UsuarioId]
                                        INNER JOIN [ToDo].[dbo].[Pessoa] AS [p] ON [p].[AggregateId] = [usu].[PessoaAggregateId]
                                        INNER JOIN [ToDo].[dbo].[PessoaFisica] AS [pf] ON [pf].[PessoaId] = [p].[Id]
                                        INNER JOIN [ToDo].[dbo].[Livro] AS [li] ON [li].[Id] = [emp].[LivroId]
                                    ORDER BY [pf].[Nome]
                                    ";
    }
}