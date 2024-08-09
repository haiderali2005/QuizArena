const mobile_nav = document.querySelector(".mobile-navbar-btn");
const nav_header = document.querySelector(".header");

if (!mobile_nav || !nav_header) {
  throw new Error("Mobile nav or nav header not found");
}

const toggleNavbar = () => {
  nav_header.classList.toggle("active");
};

mobile_nav.addEventListener("click", toggleNavbar);