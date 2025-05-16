<script lang="ts">
	import { goto } from '$app/navigation';
	import { getUser } from '$lib/stores/auth.svelte';

	let { children } = $props();

	$effect(() => {
		(async () => {
			const user = await getUser();
			if (!user) {
				goto('/');
			}
		})();
	});
</script>

{@render children()}
