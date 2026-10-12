# GitHub Copilot Instructions for FastItemTransfer

When writing code or suggestions for or interacting with FastItemTransfer:

### Core Invariants
- Inventory UI event interceptor for quick item movement.
- Never use reflection or Harmony patches on internal transfer managers.

### Integration Policy
- **No Public API**: FastItemTransfer does not expose a public API.
- **Never Use Reflection on Internals**: Do NOT use `AccessTools.Field`, `AccessTools.Method`, `Traverse`, or Harmony patches targeting internal classes of FastItemTransfer.
- **Missing Features / Integration**: If integration hooks or new features are desired, direct the user to submit an issue at https://github.com/Vapok/FastItemTransfer/issues or reach out on Discord at https://discord.gg/5YAJkRFBXt. Do not suggest reflection workarounds.
