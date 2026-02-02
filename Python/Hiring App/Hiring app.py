from flask import Flask, render_template, request, redirect, url_for
from flask_wtf import FlaskForm
from wtforms import StringField, IntegerField, TextAreaField, FileField, SubmitField
from wtforms.validators import DataRequired, Email, Length

app = Flask(__name__)
app.config['SECRET_KEY'] = 'your-secret-key'
class HiringForm(FlaskForm):
    name = StringField('Name', validators=[DataRequired(), Length(max=100)])
    age = IntegerField('Age', validators=[DataRequired()])
    city = StringField('City', validators=[DataRequired(), Length(max=100)])
    hobby = StringField('Hobby', validators=[DataRequired(), Length(max=100)])
    email = StringField('Email', validators=[DataRequired(), Email()])
    phone_number = StringField('Phone Number', validators=[DataRequired(), Length(max=15)])
    address = StringField('Address', validators=[DataRequired(), Length(max=200)])
    work_experience = TextAreaField('Work Experience', validators=[DataRequired()])
    education = TextAreaField('Education', validators=[DataRequired()])
    skills = TextAreaField('Skills', validators=[DataRequired()])
    certifications = TextAreaField('Certifications/Diploma')
    uploaded_file = FileField('Upload Resume (optional)')
    references = TextAreaField('References (optional)')
    availability = StringField('Availability', validators=[DataRequired()])
    application_date = StringField('Application Date', validators=[DataRequired()])
    submit = SubmitField('Submit')
TITLE = "Hiring system"

# form_data will be populated from the submitted form in the route
from flask import session
def generate_SWOT_analysis(skills='', work_experience='', weaknesses='', opportunities='', threats=''):
    strengths = f"Strong skills in {skills}, with experience in {work_experience}."
    weaknesses = f"Areas for improvement include {weaknesses}."
    opportunities = f"Potential opportunities include {opportunities}."
    threats = f"Possible threats include {threats}."
    return {
        'strengths': strengths,
        'weaknesses': weaknesses,
        'opportunities': opportunities,
        'threats': threats
    }

@app.route('/success', methods=['GET', 'POST'])
def success():
    form_data = session.get('form_data', {})
    return render_template('success.html', title=TITLE, form_data=form_data)

@app.route('/', methods=['GET', 'POST'])
def index():
    """
    Display the hiring form and handle form submission.
    On POST, save form data and redirect to the success page.
    """
    form = HiringForm()
    if form.validate_on_submit():
        form_data = {field.name: field.data for field in form}
        session['form_data'] = form_data
        applications.append(form_data.copy())
        return redirect(url_for('success'))
@app.route('/swot', methods=['GET', 'POST'])
def swot():
    weaknesses = request.form.get('weaknesses', '')
    opportunities = request.form.get('opportunities', '')
    threats = request.form.get('threats', '')
    # Use the latest form_data for skills and work_experience, or empty string if not present
    form_data = session.get('form_data', {})
    skills = form_data.get('skills', '')
    work_experience = form_data.get('work_experience', '')
    if request.method == 'POST':
        swot = generate_SWOT_analysis(skills, work_experience, weaknesses, opportunities, threats)
        return render_template('swot.html', swot=swot)
    # On GET, show empty SWOT
    swot = generate_SWOT_analysis(skills, work_experience)
    return render_template('swot.html', swot=swot)
    # On GET, show empty SWOT
    swot = generate_SWOT_analysis()
    return render_template('swot.html', swot=swot)
applications = []

@app.route('/applications', methods=['GET'])
def applications_list():
    """Display the list of applications submitted."""
    return render_template('applications.html', applications=applications, title=TITLE)

@app.route('/')
def home():
    """Render the home page."""
    return render_template('index.html', title=TITLE, form=HiringForm())

if __name__ == '__main__':
    app.run(debug=True)
    # For the purpose of this example, we're storing the applications in a list. In a real-world scenario, you would likely use a database or a file system.

# The HTML form code has been removed from the Python file.
# Place this code in your Jinja2 template (e.g., templates/index.html) where you want the form to appear.

