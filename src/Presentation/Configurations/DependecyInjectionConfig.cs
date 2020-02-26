using App.Business.Interfaces;
using App.Data.Repository;
using App.Datas.Context;
using Microsoft.Extensions.DependencyInjection;


namespace Presentation.Configurations
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            return services;
        }
    }
}
