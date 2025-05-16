<script lang="ts">
	import { goto } from "$app/navigation";
	import { userManager } from "$lib/stores/auth.svelte";



$effect(() => {
    (async () => {
      try {
        const user = await userManager.signinCallback();
		console.log("Singin successful: ", user);
		
		if (user) {
			goto("/home");
		}
		else {
			goto("/");
		}
	  } catch (e) {
		console.error(e);
		goto("/");
	}
	})();
});
</script>


<h1>Signing in...</h1>