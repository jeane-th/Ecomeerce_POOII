
document.addEventListener("DOMContentLoaded", () => {
    const body = document.body;
    const toggle = document.getElementById("theme-toggle");
    const sidebar = document.getElementById("sidebar");
    const sidebarToggle = document.getElementById("sidebar-toggle");

    // Tema persistente
    const savedTheme = localStorage.getItem("theme") || "dark";
    body.className = savedTheme + "-theme";

    toggle.addEventListener("click", () => {
        const newTheme = body.classList.contains("dark-theme") ? "light" : "dark";
        body.className = newTheme + "-theme";
        localStorage.setItem("theme", newTheme);
    });

    // Sidebar toggle
    sidebarToggle.addEventListener("click", () => {
        sidebar.classList.toggle("collapsed");
    });
});
