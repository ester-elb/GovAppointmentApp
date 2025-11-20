ארכיטקטורת מערכת ניהול תורים ממשלתית
סקירה כללית
מערכת REST API לניהול תורים במשרדי ממשלה, פרוסה בענן עם מסד נתונים מבוזר.

ארכיטקטורת המערכת
רכיבי המערכת
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Client Apps   │───▶│   Railway       │───▶│  MongoDB Atlas  │
│  (Web/Mobile)   │    │   (API Host)    │    │   (Database)    │
└─────────────────┘    └─────────────────┘    └─────────────────┘


טכנולוגיות
Backend: ASP.NET Core 9.0 (C#)

Database: MongoDB Atlas (Cloud)

Hosting: Railway (Cloud Platform) - לגבי שימוש בפלטפורמה זו, הערה למטה

API Documentation: Swagger/OpenAPI

Version Control: GitHub

פריסה בענן
--נעשה באמצעות פלטפורמה Railway (ולא בAQS/GCP כפי שנדרש) בגלל מגבלות של התקנות תוכנה/חשבונות משתמשים במחשב בו נעשה התרגיל
Railway Platform - 
URL: https://govappointmentapp-production.up.railway.app

Auto-deployment: מ-GitHub Repository

Environment Variables: MONGODB_CONNECTION_STRING

SSL/HTTPS: אוטומטי

Scaling: אוטומטי לפי עומס

MongoDB Atlas
Cluster: cluster0.mh11drd.mongodb.net

Database: AppointmentsDB

Collections: Appointments

Security: Network Access Control + Authentication

מבנה הפרויקט
AppointmentApi/
├── Controllers/
│   └── AppointmentController.cs    # API Endpoints
├── Models/
│   ├── Appointment.cs              # מודל תור
│   ├── Office.cs                   # מודל משרד
│   ├── User.cs                     # מודל משתמש
│   └── ServiceType.cs              # מודל סוג שירות
├── Services/
│   └── AppointmentService.cs       # לוגיקה עסקית
├── Program.cs                      # הגדרות האפליקציה
├── Dockerfile                      # הגדרות פריסה
└── appsettings.json               # קונפיגורציה


API Endpoints
תורים (Appointments)
POST /api/appointment - יצירת תור חדש

GET /api/appointment/{id} - קבלת תור לפי מזהה

GET /api/appointment/office/{officeName} - תורים לפי משרד

GET /api/appointment/city/{cityCode} - תורים לפי עיר

GET /api/appointment/citizen/{citizenId} - תורים לפי אזרח

PUT /api/appointment/{id}/cancel - ביטול תור

מודל נתונים ראשי
Appointment
{
  "id": "ObjectId",
  "office": {
    "id": "ObjectId",
    "name": "string",
    "cityCode": "int",
    "address": "string"
  },
  "citizenId": "int",
  "date": "DateTime",
  "serviceTypeId": "int",
  "status": "string"
}


אבטחה ואמינות
HTTPS: כל התקשורת מוצפנת

MongoDB Security: אימות משתמשים ובקרת גישה

Environment Variables: משתנים מוגנים

Error Handling: טיפול בשגיאות ולוגים

ביצועים
Async/Await: פעולות אסינכרוניות

Connection Pooling: MongoDB Driver

Auto-scaling: Railway Platform

CDN: Railway Edge Network

פיתוח ותחזוקה
CI/CD: פריסה אוטומטית מ-GitHub

Monitoring: Railway Logs

Documentation: Swagger UI

Version Control: Git + GitHub

דרישות מערכת
.NET 9.0 Runtime

MongoDB Driver 2.22+

Internet Connection

HTTPS Support
