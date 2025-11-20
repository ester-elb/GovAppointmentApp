# Government Appointment API

## Description
REST API for managing government office appointments.

## Features
- Create appointments
- View appointments by office
- Cancel appointments
- MongoDB Atlas integration

## API Endpoints
- `POST /api/appointment` - Create appointment
- `GET /api/appointment/{id}` - Get appointment by ID
- `GET /api/appointment/office/{officeId}` - Get appointments by office
- `PUT /api/appointment/{id}/cancel` - Cancel appointment

## Live Demo
Visit: [Your Railway URL]/swagger

## Environment Variables
- `MONGODB_CONNECTION_STRING` - MongoDB Atlas connection string
