using HOLE.Scripts;
using HOLE.Scripts.Misc;
using HOLE.Scripts.Tarkov_Stuff;

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
        public readonly Instance Instance;
        public InstanceManagerForm()
        {
            InitializeComponent();
        }
        public InstanceManagerForm(Instance instance)
        {
            Instance = instance;
            InitializeComponent();
        }

        private void InstanceEditorForm_Load(object sender, EventArgs e)
        {
            LoadVariables();
            LoadProduction();
        }

        private async void LoadVariables()
        {
            await Task.Delay(0);
            ProductionModule.Items.Clear();
            RequirementTypeBox.Items.Clear();
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
