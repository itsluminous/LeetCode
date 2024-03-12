#!/bin/bash

dir_list=()
file_list=()

# Loop through each file in the staging area
IFS=$'\n' # Set Internal Field Separator to newline to handle folder names with spaces
for file in $(git diff --cached --name-only --diff-filter=ACM); do
    old_file_name=$(basename "$file")
    new_file_name=$(echo "$old_file_name" | sed 's/ /-/g' | sed 's/\.-/-/g')
    old_dir_name=$(dirname "$file")
    new_dir_name=$(echo "$old_dir_name" | sed 's/ /-/g' | sed 's/\.-/-/g')

    # update file list
    file_list+=("$new_dir_name/$old_file_name|$new_dir_name/$new_file_name")

    # if we already encountered this folder, then skip renaming
    if [[ "$old_dir_name" != "$new_dir_name" ]] && ! [[ "${dir_list[@]}" =~ "$old_dir_name|$new_dir_name" ]]; then
        dir_list+=("$old_dir_name|$new_dir_name")
    fi
done

# now rename all folders
for entry in "${dir_list[@]}"; do
    IFS='|' read -r old new <<< "$entry"
    mv "$old" "$new"
    git add "$old"
    git add "$new"
done

# now rename all files
for entry in "${file_list[@]}"; do
    IFS='|' read -r old new <<< "$entry"
    mv "$old" "$new"
    git add "$old"
    git add "$new"
done

echo "Spaces removed in files & folders"