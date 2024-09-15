using HOLE.Scripts;
using HOLE.Scripts.Misc;
using HOLE.Scripts.Tarkov_Stuff;
using System.ComponentModel;

namespace HOLE
{
    public enum RequirementType
    {
        Area, 
        Item, 
        Tool, 
        Resource, 
        QuestComplete
    }
    public partial class InstanceManagerForm : Form
    {
        public readonly AkiInstance Instance;
        public InstanceManagerForm()
        {
            InitializeComponent();
        }
        public InstanceManagerForm(AkiInstance instance)
        {
            Instance = instance;
            InitializeComponent();
        }

        private void InstanceEditorForm_Load(object sender, EventArgs e)
        {
            LoadDataSources();
            LoadProduction();
        }

        private async void LoadDataSources()
        {
            await Task.Delay(0);
            ProductionModule.Items.Clear();
            RequirementTypeBox.Items.Clear();
            ProductionModule.DataSource = Enum.GetValues(typeof(Module))
            .Cast<Module>()
            .Select(enumValue =>
            {
                return new
                {
                    Value = enumValue,
                    Description = enumValue.GetType()?
                    .GetField(enumValue.ToString())?
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() is DescriptionAttribute descriptionAttribute ? descriptionAttribute.Description : enumValue.ToString()
                };
            })
            .ToList();
            ProductionModule.DisplayMember = "Description";
            ProductionModule.ValueMember = "Value";
            RequirementTypeBox.DataSource = Enum.GetValues(typeof(RequirementType));
            ProductionResult.DataSource = TarkovCache.Items.Values.ToArray();
            ProductionResult.DisplayMember = "Name";
        }
        

        private async void LoadProduction()
        {
            await Task.Delay(0);
            ProductionList.Items.Clear();
            ProductionList.DataSource = RecipeManager.Recipes;
            ProductionList.DisplayMember = "ToString";
        }

        private void ProductionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recipe? recipe = (Recipe?)ProductionList.SelectedItem;
            if (recipe != null) LoadRecipe((Recipe)recipe);
        }

        private async void LoadRecipe(Recipe recipe)
        {
            ProductionModule.Text = recipe.AreaType.GetDescription();
            ProductionGroup.Enabled = true;
            ProductionGroup.Text = $"{recipe}";
            ProductionDuration.Value = recipe.ProductionTime;
            ProductionCount.Value = recipe.Count;
            ProductionLimit.Value = recipe.ProductionLimitCount;
            ProductionFuelNeeded.Checked = recipe.NeedFuelForAllProductionTime;
            ProductionContinuous.Checked = recipe.Continuous;
            ProductionLocked.Checked = recipe.Locked;
            ProductionResult.Text = recipe.EndProduct;
            RequirementsList.DataSource = null;
            await LoadRequirements(recipe.Requirements);
        }
        private async Task LoadRequirements(params RecipeRequirement[] requirements)
        {
            if (requirements == null || requirements.Length == 0) return;
            RequirementsList.DataSource = requirements;
            RequirementsList.DisplayMember = "ToString";
            await Task.Delay(0);
        }

        private void RequirementsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeRequirement? requirement = (RecipeRequirement?) RequirementsList.SelectedItem;
            if(requirement != null) LoadRequirement((RecipeRequirement)requirement);
        }

        private async void LoadRequirement(RecipeRequirement requirement)
        {
            RequirementID.Text = requirement.RequirementID;
            SetRequirementType(Enum.Parse<RequirementType>(requirement.Type));
            RequirementEncoded.Checked = requirement.IsEncoded ?? false;
            RequirementFunctional.Checked = requirement.IsFunctional ?? false;
            await Task.Delay(0);
        }

        private async void SetRequirementType(RequirementType type)
        {
            RadioButton? button = null;
            switch(type)
            {
                case RequirementType.Area:
                    button = AreaButton;
                    break;
                case RequirementType.Tool:
                    button = ToolButton;
                    break;
                case RequirementType.Resource:
                    button = ResourceButton;
                    break;
                case RequirementType.Item:
                    button = ItemButton;
                    break;
                case RequirementType.QuestComplete:
                    button = QuestButton;
                    break;
            }
            if (button == null) return;
            button.Checked = true;
            await Task.Delay(0);
        }
    }
}
