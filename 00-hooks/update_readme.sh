#!/bin/bash

repo_root=$(git rev-parse --show-toplevel)

# Get the list of folders
folders=$(ls -d $repo_root/*/ | grep -v "00-hooks/")

# Update the README.md file
echo "# This repo has C# Solution for following LeetCode problems :" > "$repo_root/README.md"

# Loop through each folder and add a link to README.md
for folder in $folders; do
    folder_name=$(basename "$folder")
    echo "- [$folder_name]($folder_name)" >> "$repo_root/README.md"
done

echo -e "\n\n" >> "$repo_root/README.md"
echo "# Setting up repo in local:" >> "$repo_root/README.md"
echo "Follow instructions [here](00-hooks/readme.md)" >> "$repo_root/README.md"

# Add and commit changes
git add "$repo_root/README.md"
# git commit --amend --no-edit --no-verify

echo "Readme Updated."
