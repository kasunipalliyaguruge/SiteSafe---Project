SiteSafe AI Safety Monitoring
SiteSafe is an AI-powered safety monitoring system designed to detect unsafe behaviors and hazards on worksites in real-time. This project leverages computer vision and deep learning models to ensure workplace safety compliance and reduce accident risks.
Table of Contents
Overview
Features
Technologies
Installation
Usage
Model Details
Contributing
License
Contact
Overview
SiteSafe provides a platform to monitor construction sites, factories, or other industrial environments using real-time video feeds. It identifies unsafe behaviors, such as improper PPE usage, unsafe lifting, or proximity to hazards, and sends alerts to supervisors.
The system is built to be modular, scalable, and can integrate with existing safety protocols in industries.
Features
Real-time detection of safety violations using AI models
Alerts and notifications for detected hazards
Visualization of safety metrics (precision, recall, mAP)
Supports integration with existing CCTV or IoT devices
Easy-to-train and update AI models
Technologies
Programming Languages: Python, C# (for integration/UI modules)
Frameworks & Libraries:
PyTorch / TensorFlow for deep learning
OpenCV for computer vision
YOLO or custom object detection models
Front-end: HTML/CSS/JavaScript (for dashboard)
Database: SQLite / MySQL for logging alerts
Other Tools: Jupyter Notebook for model training and evaluation
Installation
Clone the repository:
git clone https://github.com/yourusername/sitesafe.git
Navigate to the project directory:
cd sitesafe
Install required Python dependencies:
pip install -r requirements.txt
Run the main monitoring script:
python main.py
⚠️ Make sure you have a compatible GPU and the required drivers installed for real-time AI processing.
Usage
Connect a video feed (webcam, CCTV, or video file).
Run main.py to start monitoring.
Alerts will be logged in the logs/ folder and displayed in the console or dashboard.
Use the provided evaluation scripts to check model performance on your dataset.
Model Details
SiteSafe currently uses:
YOLO-based object detection for hazard and PPE detection
CNN / CNN-LSTM hybrid for action recognition
Evaluated using metrics: Precision, Recall, mAP@50, mAP@50-95
Models are stored in the models/ directory and can be retrained using your own dataset.
Contributing
Contributions are welcome!
Fork the repository
Create a new branch (git checkout -b feature-name)
Commit your changes (git commit -m 'Add new feature')
Push to the branch (git push origin feature-name)
Open a pull request
Please ensure code is well-documented and follows Python and PEP-8 standards.
License
This project is licensed under the MIT License. See the LICENSE file for details.
Contact
Kasuni Arunodi – kasuni@example.com
Project repository: https://github.com/yourusername/sitesafe
