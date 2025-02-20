#!/usr/local/bin/bash

# note that shebang "/bin/bash" uses old bash version in mac
# in case of shell error while running script, use "/bin/bash" instead
# and make sure bash version is 4.0 or higher

# Part 1: Remove non-padded numeric duplicates
declare numeric_groups
for dir in */; do
    dir="${dir%/}"
    prefix="${dir%%-*}"
    numeric_value=$(sed 's/^0*//' <<< "$prefix")
    [[ -z "$numeric_value" ]] && numeric_value="0"
    numeric_groups["$numeric_value"]+="$dir "
done

for key in "${!numeric_groups[@]}"; do
    read -ra directories <<< "${numeric_groups[$key]}"
    if [[ ${#directories[@]} -gt 1 ]]; then
        padded_exists=0
        for dir in "${directories[@]}"; do
            dir_prefix="${dir%%-*}"
            [[ "$dir_prefix" != "$key" ]] && { padded_exists=1; break; }
        done

        if [[ $padded_exists -eq 1 ]]; then
            for dir in "${directories[@]}"; do
                dir_prefix="${dir%%-*}"
                [[ "$dir_prefix" == "$key" ]] && echo "Removing numeric non-padded: $dir" && rm -rf "$dir"
            done
        fi
    fi
done

# Part 2: Remove text-based duplicates without numeric prefixes
declare -A suffix_groups
for dir in */; do
    dir="${dir%/}"
    suffix=$(sed -E 's/^[0-9]+-//' <<< "$dir")
    suffix_groups["$suffix"]+="$dir "
done

for suffix in "${!suffix_groups[@]}"; do
    read -ra directories <<< "${suffix_groups[$suffix]}"
    if [[ ${#directories[@]} -gt 1 ]]; then
        has_numeric=0
        for dir in "${directories[@]}"; do
            if [[ "$dir" =~ ^[0-9]+- ]]; then
                has_numeric=1
                break
            fi
        done

        if [[ $has_numeric -eq 1 ]]; then
            for dir in "${directories[@]}"; do
                if [[ ! "$dir" =~ ^[0-9]+- ]]; then
                    echo "Removing text duplicate without prefix: $dir"
                    rm -rf "$dir"
                fi
            done
        fi
    fi
done
