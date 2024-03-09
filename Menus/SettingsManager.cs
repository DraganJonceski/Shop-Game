using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Menus
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fovSliderText;
        [SerializeField] private TextMeshProUGUI sensSliderText;
        public Slider fovSlider;
        public Slider sensSlider;

        private void Start()
        {
            fovSlider.value = StateNameController.FovValue;
            fovSliderText.text = fovSlider.value.ToString(CultureInfo.CurrentCulture);
            fovSlider.onValueChanged.AddListener(v => { fovSliderText.text = v.ToString(CultureInfo.CurrentCulture); });
            
            sensSlider.value = StateNameController.SensitivityValue;
            sensSliderText.text = sensSlider.value.ToString(CultureInfo.CurrentCulture);
            sensSlider.onValueChanged.AddListener(u => { sensSliderText.text = u.ToString(CultureInfo.CurrentCulture); });
        }

        private void Update()
        {
            StateNameController.FovValue = (int)fovSlider.value;
            StateNameController.SensitivityValue = (int)sensSlider.value;
        }
    }
}