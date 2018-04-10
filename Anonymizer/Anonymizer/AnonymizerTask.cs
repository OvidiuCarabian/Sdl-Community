﻿using Sdl.Community.Anonymizer.Process_Xliff;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.AutomaticTasks;
using Sdl.ProjectAutomation.Core;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;



namespace Sdl.Community.Anonymizer
{
	[AutomaticTask("Anonymizer Task",
				   "Anonymize data",
				   "Anonymize personal data batch task",
				   GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
	[AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
	[RequiresSettings(typeof(AnonymizerSettings), typeof(AnonymizerSettingsPage))]
	public class AnonymizerTask : AbstractFileContentProcessingAutomaticTask
	{
		private AnonymizerSettings _settings;
		protected override void OnInitializeTask()
		{
			_settings = GetSetting<AnonymizerSettings>();
		}


		protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
		{

			multiFileConverter.AddBilingualProcessor(new BilingualContentHandlerAdapter(new AnonymizerPreProcessor()));
		
		}

		public override bool OnFileComplete(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
		{
			return true;
		}
	}

	[Action("Anonymizer Action",
		Name = "Decrypt data",
		Description = "Deanonymize data which was previously anonymize by the batch task",
		Icon = "unlock"
	)]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.ProjectsContextMenuLocation), 2, DisplayType.Default, "",
		true)]
	public class AnonymizerDeanonymizeAction : AbstractAction
	{
		protected override void Execute()
		{

		}
	}
	[Action("Help Anonymizer Action",
		Name = "Help",
		Description = "Help",
		Icon = "question"
	)]
	[ActionLayout(typeof(TranslationStudioDefaultContextMenus.ProjectsContextMenuLocation), 2, DisplayType.Default, "",
		true)]
	public class AnonymizerHelpAction : AbstractAction
	{
		protected override void Execute()
		{
			System.Diagnostics.Process.Start("https://community.sdl.com/product-groups/translationproductivity/w/customer-experience/3199.gdpr");
		}
	}
}
