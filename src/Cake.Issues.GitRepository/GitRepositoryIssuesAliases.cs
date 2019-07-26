﻿namespace Cake.Issues.GitRepository
{
    using Cake.Core;
    using Cake.Core.Annotations;
    using Cake.Core.IO;

    /// <summary>
    /// Contains functionality related to analyze Git repositories.
    /// </summary>
    [CakeAliasCategory(IssuesAliasConstants.MainCakeAliasCategory)]
    public static class GitRepositoryIssuesAliases
    {
        /// <summary>
        /// Gets the name of the Git repository issue provider.
        /// This name can be used to identify issues based on the <see cref="IIssue.ProviderType"/> property.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Name of the Git repository issue provider.</returns>
        [CakePropertyAlias]
        [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
        public static string GitRepositoryIssuesProviderTypeName(
            this ICakeContext context)
        {
            context.NotNull(nameof(context));

            return typeof(GitRepositoryIssuesProvider).FullName;
        }

        /// <summary>
        /// Gets an instance of a provider for analyzing a Git repository and reporting issues using specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">Settings for analyzing the Git repository.</param>
        /// <returns>Instance of a provider for analyzing a Git repository and reporting issues.</returns>
        /// <example>
        /// <para>Analyze Git repository:</para>
        /// <code>
        /// <![CDATA[
        ///     var settings =
        ///         new GitRepositoryIssues();
        ///
        ///     var issues =
        ///         ReadIssues(
        ///             GitRepositoryIssues(settings),
        ///             @"c:\repo");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
        public static IIssueProvider GitRepositoryIssues(
            this ICakeContext context,
            GitRepositoryIssuesSettings settings)
        {
            context.NotNull(nameof(context));
            settings.NotNull(nameof(settings));

            return new GitRepositoryIssuesProvider(context.Log, settings);
        }
    }
}
