class Solution:
    def minimumTeachings(self, n: int, languages: list[list[int]], friendships: list[list[int]]) -> int:
        need_to_learn = set()

        for f0, f1 in friendships:
            f0 -= 1
            f1 -= 1  # convert to 0-based indexing

            # check if there is any common language
            known_lang = set(languages[f0])
            match_found = any(lang in known_lang for lang in languages[f1])

            if match_found:
                continue  # no effort needed
            need_to_learn.add(f0)
            need_to_learn.add(f1)

        # find out language that most people speak, out of those who need to learn
        max_count = 0
        lang_count = [0] * (n + 1)  # indicates how many people speak a language
        for f in need_to_learn:
            for lang in languages[f]:
                lang_count[lang] += 1
                max_count = max(max_count, lang_count[lang])

        return len(need_to_learn) - max_count  # these many people need to learn the maxCount language
