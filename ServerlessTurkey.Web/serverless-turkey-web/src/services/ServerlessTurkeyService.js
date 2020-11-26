export async function createTurkeyRecipe(data) {
    const response = await fetch(`/api/TurkeyRecipe`, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({task: data})
    })
    return await response.json();
}