class Solution:
    def countStudents(self, students: List[int], sandwiches: List[int]) -> int:
        n = len(students)

        # Count how many students prefer each sandwich type
        circle_student_count = sum(1 for stud in students if stud == 0)
        square_student_count = n - circle_student_count
        
        # For every sandwich, if there is a student anywhere who can eat, then continue, else break
        k = 0
        for k in range(n):
            if sandwiches[k] == 0:
                if circle_student_count == 0:
                    break
                circle_student_count -= 1
            else:
                if square_student_count == 0:
                    break
                square_student_count -= 1
        else:
            k = n   # when loop ends, then set k to n

        # k students could eat sandwiches
        # So those who could not eat is total minus k
        return n-k