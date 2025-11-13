# Implementation Plan: [FEATURE]

**Branch**: `[###-feature-name]` | **Date**: [DATE] | **Spec**: [link]
**Input**: Feature specification from `/specs/[###-feature-name]/spec.md`

**Note**: This template is filled in by the `/speckit.plan` command. See `.specify/templates/commands/plan.md` for the execution workflow.

## Summary

[Extract from feature spec: primary requirement + technical approach from research]

## Technical Context

<!--
  ACTION REQUIRED: Replace the content in this section with the technical details
  for the project. For CHSNS, use the modern stack defined in the constitution.
-->

**Frontend**: Vue 3 + TypeScript (strict mode) + Ant Design Vue 4.x + Vite 5+  
**Backend**: .NET 10 Web API (API-only, no views) + Entity Framework Core  
**Primary Dependencies**: [e.g., Pinia for state, axios for HTTP, FluentValidation for backend or NEEDS CLARIFICATION]  
**Storage**: [e.g., PostgreSQL, SQL Server, MongoDB or NEEDS CLARIFICATION]  
**Testing**: Vitest + Playwright (frontend), xUnit + WebApplicationFactory (backend)  
**Target Platform**: Modern browsers (Chrome, Firefox, Safari, Edge latest 2 versions) + Linux/Windows server  
**Project Type**: web (frontend + backend API in monorepo)  
**Performance Goals**: [e.g., <100ms API response time, 60fps UI, <3s initial load or NEEDS CLARIFICATION]  
**Constraints**: [e.g., <200ms p95, mobile-responsive, accessibility WCAG 2.1 AA or NEEDS CLARIFICATION]  
**Scale/Scope**: [e.g., 10k concurrent users, 1M records, 100+ API endpoints or NEEDS CLARIFICATION]

## Constitution Check

_GATE: Must pass before Phase 0 research. Re-check after Phase 1 design._

- [ ] **Component-Based Architecture**: Feature designed as modular components with clear boundaries? TypeScript strict mode enabled?
- [ ] **API-First Development**: API contracts documented before implementation? Backend provides ONLY APIs (no views)?
- [ ] **Test-Driven Development**: Test strategy defined with acceptance criteria?
- [ ] **Progressive Migration**: If touching legacy code, migration approach documented?
- [ ] **Observability**: Logging, error handling, and monitoring approach defined?
- [ ] **Technology Stack**: Using modern stack (Vue 3 + TypeScript strict + Ant Design Vue / .NET 10 Web API only)?
- [ ] **Strict Typing**: All props, emits, functions have explicit types? No `any` types used?
- [ ] **Quality Gates**: Tests, linting, type checking, code review, and documentation plan in place?

_Any violations MUST be justified in the Complexity Tracking section below._

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

| Violation                  | Why Needed         | Simpler Alternative Rejected Because |
| -------------------------- | ------------------ | ------------------------------------ |
| [e.g., 4th project]        | [current need]     | [why 3 projects insufficient]        |
| [e.g., Repository pattern] | [specific problem] | [why direct DB access insufficient]  |
