using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using EntityFrameworkRuler.Design.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkRuler.Design {
    /// <summary>
    /// Used to the configure design-time services for this library.
    /// </summary>
    public sealed class RuledDesignTimeServices : IDesignTimeServices {
        /// <summary> Creates RuledDesignTimeServices </summary>
        public RuledDesignTimeServices() {
#if DEBUG
            if (Debugger.IsAttached) return;
            var entryAssembly = Assembly.GetEntryAssembly();
            var entryName = entryAssembly?.GetName();
            if (entryName?.Name.In("ef", "dotnet-ef") == true) {
                DesignTimeRuleLoader.DebugLog($"Detected EF Tools v{entryName.Version}");
                Debugger.Launch();
            }

#endif
        }

        /// <summary> Adds this library's design-time services to the service collection. </summary>
        /// <param name="services">The service collection.</param>
        [SuppressMessage("Usage", "EF1001:Internal EF Core API usage.")]
        public void ConfigureDesignTimeServices(IServiceCollection services) {
            services.AddSingleton<IPluralizer, RuledPluralizer>();
            //services.AddSingleton<IScaffoldingTypeMapper, EfRulerScaffoldingTypeMapper>();
            services.AddSingleton<ICandidateNamingService, RuledCandidateNamingService>();
            services.AddSingleton<IScaffoldingModelFactory, RuledRelationalScaffoldingModelFactory>();
            services.AddSingleton<IReverseEngineerScaffolder, RuledReverseEngineerScaffolder>();
            //services.AddSingleton<ICandidateNamingService, CandidateNamingService>();
            services.AddSingleton<IDesignTimeRuleLoader, DesignTimeRuleLoader>();
            services.AddRuleLoader();
        }
    }
}