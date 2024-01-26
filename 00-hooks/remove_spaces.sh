#!/bin/bash

repo_root=$(git rev-parse --show-toplevel)

# Get the list of folders
folders=$(find $repo_root -maxdepth 1 -type d -name "* *")

# Loop through each folder and rename
IFS=$'\n' # Set Internal Field Separator to newline to handle folder names with spaces
for folder in $folders; do
    parent_path=$(dirname "$folder")
    old_name=$(basename "$folder")
    new_name=$(echo "$old_name" | sed 's/ /-/g' | sed 's/\.-/-/g')
    mv "$parent_path/$old_name" "$parent_path/$new_name"
    git add "$parent_path/$new_name"
done

# Add and commit changes
# git commit --amend --no-edit --no-verify

echo "Spaces removed in folders"
