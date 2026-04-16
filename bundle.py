import os

# Base path
base_path = r"C:\Development\SpacePodcast\Obsidian"

# Output folder (will be created next to the script)
output_dir = r"C:\Development\SpacePodcast\Combined_Markdown"
os.makedirs(output_dir, exist_ok=True)

# List of all .md files with their grouping key (the first folder after \Obsidian\)
files_to_combine = [
    (r"00_Station_Overview.md", "00_Station_Overview"),
    (r"01_Central_Spine.md", "01_Central_Spine"),
    (r"02_Ring_Architecture.md", "02_Ring_Architecture"),
    (r"03_Rings_Index.md", "03_Rings_Index"),
    (r"04_Spoke_and_Hub_Design.md", "04_Spoke_and_Hub_Design"),
    (r"05_External_Structures.md", "05_External_Structures"),
    (r"06_Secondary_Spines.md", "06_Secondary_Spines"),
    (r"variety_seeds.md", "variety_seeds"),

    (r"Appendix\Orientation System.md", "Appendix"),
    (r"Appendix\Rotational_Transfer_Sleeves.md", "Appendix"),
    (r"Appendix\Station_Terminology.md", "Appendix"),
    (r"Appendix\Transit Couplings.md", "Appendix"),
    (r"Appendix\Transport_System.md", "Appendix"),

    (r"Episodes\S01\E01\refs.md", "Episodes"),
    (r"Episodes\S01\E01\script.md", "Episodes"),

    (r"Locations\Administration.md", "Locations"),
    (r"Locations\Assembly_Space.md", "Locations"),
    (r"Locations\Atmospheric_Processing.md", "Locations"),
    (r"Locations\Bulk_Storage.md", "Locations"),
    (r"Locations\Civic_Administration.md", "Locations"),
    (r"Locations\Communications.md", "Locations"),
    (r"Locations\Diagnostics.md", "Locations"),
    (r"Locations\Distribution.md", "Locations"),
    (r"Locations\Education.md", "Locations"),
    (r"Locations\Environmental_Control.md", "Locations"),
    (r"Locations\Fabrication.md", "Locations"),
    (r"Locations\Freight_Handling.md", "Locations"),
    (r"Locations\Growth_Control.md", "Locations"),
    (r"Locations\Habitation.md", "Locations"),
    (r"Locations\Heavy_Maintenance.md", "Locations"),
    (r"Locations\Hydroponics.md", "Locations"),
    (r"Locations\Isolation_Ward.md", "Locations"),
    (r"Locations\Machine_Hall.md", "Locations"),
    (r"Locations\Maintenance.md", "Locations"),
    (r"Locations\Medical.md", "Locations"),
    (r"Locations\Nutrient_Processing.md", "Locations"),
    (r"Locations\Power_Distribution.md", "Locations"),
    (r"Locations\Processing.md", "Locations"),
    (r"Locations\Public_Services.md", "Locations"),
    (r"Locations\Recreation.md", "Locations"),
    (r"Locations\Research.md", "Locations"),
    (r"Locations\Security.md", "Locations"),
    (r"Locations\Storage.md", "Locations"),
    (r"Locations\Transit.md", "Locations"),
    (r"Locations\Transit_Interchange.md", "Locations"),
    (r"Locations\Utility_Systems.md", "Locations"),
    (r"Locations\Waste_Processing.md", "Locations"),
    (r"Locations\Water_Treatment.md", "Locations"),

    (r"Locations\Named\Aft Maintenance Corridor.md", "Locations_Named"),
    (r"Locations\Named\Aurelian Gallery.md", "Locations_Named"),
    (r"Locations\Named\Cosmic Burger.md", "Locations_Named"),
    (r"Locations\Named\Halden Works.md", "Locations_Named"),
    (r"Locations\Named\Halycon Observation Walk.md", "Locations_Named"),
    (r"Locations\Named\Helios Garden.md", "Locations_Named"),
    (r"Locations\Named\Lantern Court.md", "Locations_Named"),
    (r"Locations\Named\Lumen Arcade.md", "Locations_Named"),
    (r"Locations\Named\Meridian Learning Annex.md", "Locations_Named"),
    (r"Locations\Named\Northlight Counter.md", "Locations_Named"),
    (r"Locations\Named\Orpheus Transit Hub.md", "Locations_Named"),
    (r"Locations\Named\Pamela Fountain.md", "Locations_Named"),
    (r"Locations\Named\The Glass Mile.md", "Locations_Named"),
    (r"Locations\Named\The Long Archive.md", "Locations_Named"),
    (r"Locations\Named\The Quiet Exchange.md", "Locations_Named"),
    (r"Locations\Named\The Ribbon Walk.md", "Locations_Named"),
    (r"Locations\Named\The Second Table.md", "Locations_Named"),

    (r"Rings\Delta\Overview.md", "Rings"),
    (r"Rings\Delta\Q1.md", "Rings"),
    (r"Rings\Delta\Q2.md", "Rings"),
    (r"Rings\Delta\Q3.md", "Rings"),
    (r"Rings\Delta\Q4.md", "Rings"),
    (r"Rings\Epsilon\Overview.md", "Rings"),
    (r"Rings\Epsilon\Q1.md", "Rings"),
    (r"Rings\Epsilon\Q2.md", "Rings"),
    (r"Rings\Epsilon\Q3.md", "Rings"),
    (r"Rings\Epsilon\Q4.md", "Rings"),
    (r"Rings\Gamma\Overview.md", "Rings"),
    (r"Rings\Gamma\Q1.md", "Rings"),
    (r"Rings\Gamma\Q2.md", "Rings"),
    (r"Rings\Gamma\Q3.md", "Rings"),
    (r"Rings\Gamma\Q4.md", "Rings"),
    (r"Rings\Kappa\Overview.md", "Rings"),
    (r"Rings\Kappa\Q1.md", "Rings"),
    (r"Rings\Kappa\Q2.md", "Rings"),
    (r"Rings\Kappa\Q3.md", "Rings"),
    (r"Rings\Kappa\Q4.md", "Rings"),
    (r"Rings\Lambda\Overview.md", "Rings"),
    (r"Rings\Lambda\Q1.md", "Rings"),
    (r"Rings\Lambda\Q2.md", "Rings"),
    (r"Rings\Lambda\Q3.md", "Rings"),
    (r"Rings\Lambda\Q4.md", "Rings"),
    (r"Rings\Omicron\Overview.md", "Rings"),
    (r"Rings\Omicron\Q1.md", "Rings"),
    (r"Rings\Omicron\Q2.md", "Rings"),
    (r"Rings\Omicron\Q3.md", "Rings"),
    (r"Rings\Omicron\Q4.md", "Rings"),
    (r"Rings\Theta\Overview.md", "Rings"),
    (r"Rings\Theta\Q1.md", "Rings"),
    (r"Rings\Theta\Q2.md", "Rings"),
    (r"Rings\Theta\Q3.md", "Rings"),
    (r"Rings\Theta\Q4.md", "Rings"),
    (r"Rings\Zeta\Overview.md", "Rings"),
    (r"Rings\Zeta\Q1.md", "Rings"),
    (r"Rings\Zeta\Q2.md", "Rings"),
    (r"Rings\Zeta\Q3.md", "Rings"),
    (r"Rings\Zeta\Q4.md", "Rings"),
]

# Combine files by group
groups = {}
for relative_path, group_name in files_to_combine:
    full_path = os.path.join(base_path, relative_path)
    
    if not os.path.exists(full_path):
        print(f"Warning: File not found: {full_path}")
        continue
    
    if group_name not in groups:
        groups[group_name] = []
    
    groups[group_name].append(full_path)

# Write combined files
for group_name, file_list in groups.items():
    output_file = os.path.join(output_dir, f"{group_name}.md")
    
    with open(output_file, "w", encoding="utf-8") as outfile:
        outfile.write(f"# {group_name.replace('_', ' ')}\n\n")
        outfile.write(f"Combined on: {os.path.basename(output_file)}\n\n")
        outfile.write("---\n\n")
        
        for file_path in file_list:
            filename = os.path.basename(file_path)
            try:
                with open(file_path, "r", encoding="utf-8") as infile:
                    content = infile.read()
                
                outfile.write(f"## {filename}\n\n")
                outfile.write(content)
                outfile.write("\n\n---\n\n")
                
                print(f"Added: {filename} → {group_name}.md")
            except Exception as e:
                print(f"Error reading {file_path}: {e}")

print("\nDone! All combined files have been saved to:")
print(output_dir)