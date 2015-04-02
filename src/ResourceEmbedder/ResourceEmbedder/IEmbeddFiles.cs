﻿namespace ResourceEmbedder
{
	/// <summary>
	/// Interface for a resource embedder.
	/// </summary>
	public interface IEmbeddFiles
	{
		/// <summary>
		/// The logger used during the embedding.
		/// </summary>
		ILogger Logger { get; }

		/// <summary>
		/// Call to embedd the provided set of resources into the specific assembly.
		/// Uses the <see cref="Logger"/> to issue log messages.
		/// </summary>
		/// <param name="targetAssembly">The assembly where the resources should be embedded in.</param>
		/// <param name="resourcesToEmbedd"></param>
		/// <returns></returns>
		bool EmbedResources(string targetAssembly, ResourceInfo[] resourcesToEmbedd);
	}
}