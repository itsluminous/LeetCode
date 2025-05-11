#!/usr/local/bin/bash

# note that shebang "/bin/bash" uses old bash version in mac
# in case of shell error while running script, use "/bin/bash" instead
# and make sure bash version is 4.0 or higher

# Exit immediately if a command exits with a non-zero status.
set -e
# Treat unset variables as an error when substituting.
set -u

echo "Starting organization of directories by number range..."

# Loop through all items that are directories in the current location
# The trailing / ensures only directories are matched by the glob
for problem_dir in */; do
    # Remove the trailing slash from the directory name for easier processing
    dir_name="${problem_dir%/}"

    # Use a regex to check if the directory name starts with digits followed by a hyphen
    # and capture the digits.
    if [[ "$dir_name" =~ ^([0-9]+)- ]]; then
        # Extract the captured number (the part inside the parentheses)
        problem_number="${BASH_REMATCH[1]}"

        # Convert the extracted number to an integer.
        # Use 10# prefix to ensure it's treated as base 10, even if it has leading zeros (like 0214).
        num_int=$((10#$problem_number))

        # Problem numbers start from 1 for range calculation (0033 is problem 33).
        if (( num_int > 0 )); then
            # Calculate the range block index (0 for 1-500, 1 for 501-1000, etc.)
            # (num_int - 1) / 500 performs integer division.
            block_index=$(( (num_int - 1) / 500 ))

            # Calculate the start number of the range (e.g., block 0 starts at 1, block 1 starts at 501)
            range_start=$(( block_index * 500 + 1 ))

            # Calculate the end number of the range
            range_end=$(( block_index * 500 + 500 ))

            # Format the start and end numbers with leading zeros to be at least 4 digits wide
            formatted_start=$(printf "%04d" $range_start)
            formatted_end=$(printf "%04d" $range_end)

            # Construct the name for the parent range directory
            parent_range_dir="${formatted_start}-${formatted_end}"

            # Create the parent range directory if it doesn't already exist (-p flag)
            mkdir -p "$parent_range_dir"

            # Move the problem directory into the corresponding parent range directory
            echo "Moving '$dir_name' to '$parent_range_dir/'"
            mv "$problem_dir" "$parent_range_dir/"
        else
             echo "Skipping directory '$dir_name': Number is 0 or invalid for range grouping."
        fi
    else
        # Handle directories that do not start with a number followed by a hyphen
        echo "Skipping directory '$dir_name': Does not match expected number- format."
    fi
done

echo "Organization complete."