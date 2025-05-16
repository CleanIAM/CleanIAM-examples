<script lang="ts">
	import { goto } from "$app/navigation";
	import { getUser } from "$lib/stores/auth.svelte";
	import type { User } from "oidc-client-ts";

	var user: User| null = $state(null);
	$effect(() => {
		(async () => {
			user = await getUser();

			if (user) {
				goto("/home");
			}
		})();
	});
</script>

<div class="flex flex-col items-center justify-center min-h-screen bg-gray-100 p-6">
	<div class="bg-white shadow-lg rounded-2xl p-8 max-w-md w-full text-center">
		<h1 class="text-2xl font-semibold text-gray-800 mb-4">Welcome</h1>

			<p class="text-lg text-gray-600">Welcome! Please <a href="/signin" class="text-blue-500 hover:underline">sign in</a>.</p>
	</div>
</div>
