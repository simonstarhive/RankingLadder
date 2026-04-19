#  RankingApp

### ASP.NET MVC + Spring Boot Full-Stack Application


A full-stack web app for managing and viewing tennis rankings and scores, built with **ASP.NET MVC (frontend)** and a **Spring Boot REST API (backend)**.

---

#  Features

###  User

* View **Men’s & Women’s Rankings**
* View match **Scores**
* **Signup & Login**
* Session-based authentication

###  Admin

* Admin dashboard
* Manage rankings & scores
* Add users

---

#  Tech Stack

## Frontend

* ASP.NET Core MVC
* Razor Views (.cshtml)
* Tailwind-style UI

## Backend

* Spring Boot (Java)
* REST API (JSON)
* Spring Security

## Communication

* `HttpClient` (ASP.NET → API)

---

#  Project Structure

```bash
RankingApp/
│
├── Controllers/
├── Models/
├── Services/
├── Views/
│   ├── Auth/
│   ├── Ranking/
│   ├── Score/
│   ├── Admin/
│   ├── User/
│   └── Shared/
│
└── Program.cs
```

---

#  Getting Started

##  Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/)
* Java 17+
* Maven or Gradle
* Node.js (optional for Tailwind)

---

##  1. Run Backend (Spring Boot)

Navigate to your backend project:

```bash
cd backend
```

Run:

```bash
./mvnw spring-boot:run
```

Server runs at:

```bash
http://localhost:8080
```

---

###  Test API

Open browser:

```bash
http://localhost:8080/rankings
```

You should see JSON.

---

##  Spring Security Config (IMPORTANT)

Make sure your backend allows requests:

```java
@Bean
public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
    http
        .csrf(csrf -> csrf.disable())
        .authorizeHttpRequests(auth -> auth
            .requestMatchers("/auth/**").permitAll()
            .requestMatchers("/rankings/**").permitAll()
            .requestMatchers("/scores/**").permitAll()
            .anyRequest().permitAll()
        )
        .httpBasic(httpBasic -> httpBasic.disable());

    return http.build();
}
```

---

##  2. Run Frontend (ASP.NET MVC)

```bash
cd RankingApp
dotnet run
```

App runs at:

```bash
https://localhost:7035
```

---

#  Routes

| Page             | URL                   |
| ---------------- | --------------------- |
| Login            | `/Auth/Login`         |
| Signup           | `/Auth/Signup`        |
| Rankings (Men)   | `/Ranking/Mens`       |
| Rankings (Women) | `/Ranking/Womens`     |
| Scores (Men)     | `/Score/Mens`         |
| Scores (Women)   | `/Score/Womens`       |
| User Dashboard   | `/User/Welcome`       |
| Admin Panel      | `/Admin/AdminWelcome` |

---

#  API Integration

Example:

```csharp
var res = await _http.GetStringAsync("http://localhost:8080/rankings");
```

---

#  Common Issues

###  “No response from server”

* Make sure backend is running on port `8080`

###  Login popup appears

* Disable `.httpBasic()` in Spring Security

###  404 errors

* Use correct endpoints e.g (`/rankings`, not `/ranking`)

###  JSON parsing errors

* Ensure backend returns valid JSON

---

#  Deployment Guide

##  Backend Deployment (Spring Boot)

### Option 1 — Render

1. Push backend to GitHub
2. Go to https://render.com
3. Create **Web Service**
4. Build command:

```bash
./mvnw clean install
```

5. Start command:

```bash
java -jar target/*.jar
```

---

### Option 2 — Railway

* Connect repo
* Auto-detect Spring Boot
* Deploy

---

##  Frontend Deployment (ASP.NET MVC)

### Option 1 — Azure App Service

1. Create App Service
2. Publish via Visual Studio
3. Set environment variables:

   * API base URL

---

### Option 2 — IIS (Windows Server)

1. Publish project:

```bash
dotnet publish -c Release
```

2. Host in IIS

---

##  IMPORTANT (Production)

Update API URL:

```csharp
"http://your-api-url.com/rankings"
```

---

#  Future Improvements

* JWT Authentication
* Role-based authorization middleware
* Full React frontend migration
* Database integration (MySQL/PostgreSQL)
* Real-time updates


---

#  License

MIT License

---

# Support

If you found this helpful, consider starring the repo 

---

#  Author

Angel Wu

Built as a full-stack project using:

* ASP.NET MVC
* Spring Boot API
* Authentication systems
* Modern UI practices
