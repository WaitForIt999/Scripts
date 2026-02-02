public class PoliticalEntity
{
    public String name;
    public String econ;
    public float authority;
    public float culture;
    public float aiEthinicity;
    public float alienEthinics;

    public PoliticalEntity(String name, String econ, float authority, float culture, float aiEthinicity, float alienEthinics)
    {
        this.name = name;
        this.econ = econ; //x 
        this.authority = authority; //y
        this.culture = culture; //z
        this.aiEthinicity = aiEthinicity; //W
        this.alienEthinics = alienEthinics; //V
    }

}
using UnityEngine;

public static class FadeUtils
{
    public static void FadeLayer(GameObject layer, float targetAlpha, float speed)
    {
        foreach (var renderer in layer.GetComponentsInChildren<Renderer>())
        {
            foreach (var mat in renderer.materials)
            {
                Color c = mat.color;
                c.a = Mathf.Lerp(c.a, targetAlpha, speed * Time.deltaTime);
                mat.color = c;
            }
        }
    }
}

string[] econ = {
    "Agrarian",
    "Industrial",
    "Technological",
    "Post-Scarcity"
};
string[] authority = {
    "Anarchy",
    "Libertarian",
    "Egalitarian",
    "Authoritarian"
};
string[] culture = {
    "Individualist",
    "Collectivist",
    "Militarist",
    "Pacifist"
};
string[] aiEthinicity = {
    "Low",
    "Medium",
    "High",
    "Synthetic"
};
string[] alienEthinics = {
    "Low",
    "Medium",
    "High",
    "Integrated"
};