import unittest
from Hiring_app import generate_SWOT_analysis  # If your file is named 'Hiring_app.py'
# OR, if your file is named 'Hiring app.py', use:
# from Hiring_app import generate_SWOT_analysis
# If your file is named 'Hiring app.py', rename it to 'Hiring_app.py' or 'hiring_app.py' for import to work.

class TestGenerateSWOTAnalysis(unittest.TestCase):
    pass

if __name__ == '__main__':
    unittest.main()
def test_generate_swot_analysis_grammar_and_punctuation(self):
    skills = "Python, JavaScript"
    work_experience = "web development"
    weaknesses = "public speaking"
    opportunities = "emerging technologies"
    threats = "market competition"

    swot = generate_SWOT_analysis(skills, work_experience, weaknesses, opportunities, threats)

    self.assertEqual(swot['strengths'], "Strong skills in Python, JavaScript, with experience in web development.")
    self.assertEqual(swot['weaknesses'], "Areas for improvement include public speaking.")
    self.assertEqual(swot['opportunities'], "Potential opportunities include emerging technologies.")
    self.assertEqual(swot['threats'], "Possible threats include market competition.")

    for value in swot.values():
        self.assertTrue(value.endswith('.'), f"Sentence '{value}' does not end with a period.")
        self.assertTrue(value[0].isupper(), f"Sentence '{value}' does not start with a capital letter.")