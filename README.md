# 🚧 SiteSafe AI Safety Monitoring

**SiteSafe** is an AI-powered safety monitoring system designed to detect PPE Compliance and fatigue behavior of workers in real-time. This project leverages computer vision and deep learning models to ensure workplace safety compliance and reduce accident risks.

---

## 📑 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Model Details](#model-details)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## 📌 Overview

SiteSafe provides a platform to monitor construction sites, factories, or other industrial environments using real-time video feeds.  

It identifies unsafe behaviors such as:
- Improper PPE usage  
- Unsafe lifting  
- Proximity to hazards  

and sends alerts to supervisors.

The system is **modular, scalable**, and can integrate with existing safety protocols in industries.

---

## ✅ Features

- Real-time detection of safety violations using AI models  
- Alerts and notifications for detected hazards  
- Visualization of safety metrics (**precision, recall, mAP**)  
- Integration with CCTV or IoT devices  
- Easy-to-train and update AI models  

---

## 🛠 Technologies

### **Programming Languages**
- Python  
- C# *(for integration/UI modules)*  

### **Frameworks & Libraries**
- PyTorch / TensorFlow *(deep learning)*  
- OpenCV *(computer vision)*  
- YOLO *(object detection)*  

### **Frontend**
- HTML / CSS / JavaScript *(dashboard)*  

### **Database**
- SQLite / MySQL *(logging alerts)*  

### **Other Tools**
- Jupyter Notebook *(model training & evaluation)*  

---

## ⚙️ Installation

### 1. Clone the repository
```bash
git clone https://github.com/yourusername/sitesafe.git
---
### 2. Navigate to the project directory
```bash
cd sitesafe
### 3. Install dependencies
pip install -r requirements.txt
4. Run the application
python main.py
⚠️ Important: Ensure you have a compatible GPU and required drivers for real-time AI processing.
▶️ Usage
Connect a video feed (webcam, CCTV, or video file)
Run main.py to start monitoring
Alerts will be logged in the logs/ folder and displayed in the dashboard
Use evaluation scripts to check model performance
🤖 Model Details
SiteSafe uses:
YOLO-based object detection for hazard and PPE detection
CNN / CNN-LSTM hybrid for action recognition
📊 Evaluation Metrics
Precision
Recall
mAP@50
mAP@50-95
Models are stored in the models/ directory and can be retrained with custom datasets.
🤝 Contributing
Contributions are welcome!
Fork the repository
Create a branch
git checkout -b feature-name
Commit your changes
git commit -m "Add new feature"
Push to GitHub
git push origin feature-name
Open a Pull Request
Please follow PEP-8 standards and ensure proper documentation.
📄 License
This project is licensed under the MIT License.
See the LICENSE file for details.
📬 Contact
Kasuni Arunodi
📧 kasuni@example.com
🔗 Project Repository:
https://github.com/yourusername/sitesafe


