
const navigation = document.querySelectorAll(".navigation ul a");

for (const link of navigation){
	link.addEventListener("click", handler);
}

function handler(event){
	event.preventDefault();
	const href = this.getAttribute("href");

	document.querySelector(href).scrollIntoView({
		behavior: "smooth"
	});
}
