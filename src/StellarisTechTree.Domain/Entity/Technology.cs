namespace StellarisTechTree.Domain.Entity;

[Obsolete("Need to be finalized before usage")]
public class Technology
{
    /*
     * Technology cost
     */
    public int Cost { get; set; }

    /*
     * Research tree: physics, society, engineering
     */
    public string Area { get; set; }

    /*
     * Tech is researched on the game start
     */
    public bool IsStartTech { get; set; }

    /*
     * Tier of technology: 1, 2, 3, 4, 5
     */
    public int Tier { get; set; }

    /*
     * Indicates that tech have rare indicator
     */
    public bool IsRare { get; set; }

    /*
     * Category of technology
     */
    public string Category { get; set; }

    /*
     * Other technologies that's are required for this tech to be eligible to show
     */
    public string[] Prerequisites { get; set; }

    /*
     * Weight of technology
     */
    public int Weight { get; set; }
    
    /*
     * ai_update_type
     * does only military or all empires will priorities this tech
     */
    public bool OnlyMilitaryType { get; set; }

    /*
     * Technology that is gateway opens multiple other techs?
     */
    public string Gateway { get; set; }
}