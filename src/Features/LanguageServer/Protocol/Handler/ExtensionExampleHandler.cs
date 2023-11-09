// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.LanguageServer.Handler
{

    [ExportCSharpVisualBasicStatelessLspService(typeof(ExtensionExampleHandler)), Shared]
    [Method(BuildOnlyDiagnosticIdsMethodName)]
    [method: ImportingConstructor]
    [method: Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
    internal sealed class ExtensionExampleHandler()
                : ILspServiceRequestHandler<string>
    {
        public const string BuildOnlyDiagnosticIdsMethodName = "extensions/exampleHandler";

        public bool MutatesSolutionState => false;
        public bool RequiresLSPSolution => true;

        public Task<string> HandleRequestAsync(RequestContext context, CancellationToken cancellationToken)
        {
            var result = "Hello from Roslyn extension";
            return Task.FromResult(result);
        }
    }
}
