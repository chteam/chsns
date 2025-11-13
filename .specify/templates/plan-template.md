# Implementation Plan: [FEATURE]

**Branch**: `[###-feature-name]` | **Date**: [DATE] | **Spec**: [link]
**Input**: Feature specification from `/specs/[###-feature-name]/spec.md`

**Note**: This template is filled in by the `/speckit.plan` command. See `.specify/templates/commands/plan.md` for the execution workflow.

## Summary

[Extract from feature spec: primary requirement + technical approach from research]

## Technical Context

<!--
  ACTION REQUIRED: Replace the content in this section with the technical details
  for the project. The structure here is presented in advisory capacity to guide
  the iteration process.
-->

**Language/Version**: [e.g., Python 3.11, Swift 5.9, Rust 1.75 or NEEDS CLARIFICATION]  
**Primary Dependencies**: [e.g., FastAPI, UIKit, LLVM or NEEDS CLARIFICATION]  
**Storage**: [if applicable, e.g., PostgreSQL, CoreData, files or N/A]  
**Testing**: [e.g., pytest, XCTest, cargo test or NEEDS CLARIFICATION]  
**Target Platform**: [e.g., Linux server, iOS 15+, WASM or NEEDS CLARIFICATION]
**Project Type**: [single/web/mobile - determines source structure]  
**Performance Goals**: [domain-specific, e.g., 1000 req/s, 10k lines/sec, 60 fps or NEEDS CLARIFICATION]  
**Constraints**: [domain-specific, e.g., <200ms p95, <100MB memory, offline-capable or NEEDS CLARIFICATION]  
**Scale/Scope**: [domain-specific, e.g., 10k users, 1M LOC, 50 screens or NEEDS CLARIFICATION]

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

- [ ] **Component-Based Architecture**: Feature designed as modular components with clear boundaries?
- [ ] **API-First Development**: API contracts documented before implementation (if backend changes)?
- [ ] **Test-Driven Development**: Test strategy defined with acceptance criteria?
- [ ] **Progressive Migration**: If touching legacy code, migration approach documented?
- [ ] **Observability**: Logging, error handling, and monitoring approach defined?
- [ ] **Technology Stack**: Using approved frontend (Vue 3 + Ant Design Vue) and backend (.NET 10) stack?
- [ ] **Quality Gates**: Tests, code review, and documentation plan in place?

*Any violations MUST be justified in the Complexity Tracking section below.*

## Project Structure

### Documentation (this feature)

```text
specs/[###-feature]/
├── plan.md              # This file (/speckit.plan command output)
├── research.md          # Phase 0 output (/speckit.plan command)
├── data-model.md        # Phase 1 output (/speckit.plan command)
├── quickstart.md        # Phase 1 output (/speckit.plan command)
├── contracts/           # Phase 1 output (/speckit.plan command)
└── tasks.md             # Phase 2 output (/speckit.tasks command - NOT created by /speckit.plan)
```

### Source Code (repository root)
<!--
  ACTION REQUIRED: Replace the placeholder tree below with the concrete layout
  for this feature. Delete unused options and expand the chosen structure with
  real paths (e.g., frontend/src/components/user, backend/src/services/auth).
  The delivered plan must not include Option labels.
-->

```text
# [REMOVE IF UNUSED] Option 1: Single library/tool (for standalone utilities)
src/
├── models/
├── services/
├── cli/
└── lib/

tests/
├── contract/
├── integration/
└── unit/

# [DEFAULT FOR CHSNS] Option 2: Web application (frontend + backend)
frontend/
├── src/
│   ├── components/       # Vue components
│   ├── views/           # Page-level components
│   ├── services/        # API client services
│   ├── stores/          # Pinia state stores
│   ├── composables/     # Composition API functions
│   └── utils/           # Helper functions
└── tests/
    ├── unit/            # Component unit tests
    └── e2e/             # End-to-end tests

backend/
├── src/
│   ├── Controllers/     # API controllers
│   ├── Services/        # Business logic services
│   ├── Models/          # Data models/entities
│   ├── Repositories/    # Data access layer
│   └── Middleware/      # Custom middleware
└── tests/
    ├── Unit/            # Service unit tests
    └── Integration/     # API integration tests

# Note: Legacy code in Src/ folder should NOT be modified directly
# unless actively being migrated. Document migration approach in plan.
```

**Structure Decision**: [Document the selected structure and reference the real
directories captured above]

## Complexity Tracking

> **Fill ONLY if Constitution Check has violations that must be justified**

| Violation | Why Needed | Simpler Alternative Rejected Because |
|-----------|------------|-------------------------------------|
| [e.g., 4th project] | [current need] | [why 3 projects insufficient] |
| [e.g., Repository pattern] | [specific problem] | [why direct DB access insufficient] |
