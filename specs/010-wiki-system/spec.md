# Feature Specification: Wiki知识库系统

**Feature Branch**: `010-wiki-system`  
**Created**: 2025-11-14  
**Status**: Draft  
**Input**: Wiki知识库系统：创建Wiki词条、编辑词条内容、词条版本历史、词条分类标签、词条搜索、词条链接引用、协作编辑、词条审核

## User Scenarios & Testing *(mandatory)*

### User Story 1 - 创建和发布词条 (Priority: P1)

用户可以创建 Wiki 词条，编辑标题和内容，发布后供其他用户查看。

**Why this priority**: 词条创建是 Wiki 系统的基础，用户需要贡献知识和信息。

**Independent Test**: 用户点击"创建词条"按钮，输入标题"Vue.js"和内容，发布后在 Wiki 首页看到该词条。

**Acceptance Scenarios**:

1. **Given** 用户在 Wiki 页面, **When** 点击"创建词条", **Then** 打开词条编辑页面
2. **Given** 用户编辑词条, **When** 输入标题和内容并发布, **Then** 词条保存并显示在 Wiki 列表
3. **Given** 用户创建词条, **When** 标题为空, **Then** 系统提示"词条标题不能为空"
4. **Given** 用户创建词条, **When** 标题已存在, **Then** 系统提示"词条标题已存在，建议编辑现有词条"
5. **Given** 用户发布词条, **When** 内容超过 50000 字符, **Then** 系统提示"内容过长"
6. **Given** 用户发布词条, **When** 词条包含代码块, **Then** 支持 Markdown 格式和代码高亮
7. **Given** 用户发布词条, **When** 保存成功, **Then** 系统生成"创建词条"动态事件

---

### User Story 2 - 编辑词条内容 (Priority: P1)

用户可以编辑已有的词条，修改内容，系统保存编辑历史版本。

**Why this priority**: Wiki 是协作编辑的知识库，用户需要持续完善词条内容。

**Independent Test**: 用户点击词条的"编辑"按钮，修改内容并保存，验证新版本生成并显示。

**Acceptance Scenarios**:

1. **Given** 用户查看词条, **When** 点击"编辑"按钮, **Then** 打开编辑页面并预填充当前内容
2. **Given** 用户编辑词条, **When** 修改内容并保存, **Then** 词条更新并生成新版本
3. **Given** 用户编辑词条, **When** 保存时填写编辑摘要, **Then** 编辑摘要记录在版本历史中
4. **Given** 用户编辑词条, **When** 与他人同时编辑, **Then** 系统检测冲突并提示合并（可选功能）
5. **Given** 用户编辑词条, **When** 编辑时间超过 30 分钟, **Then** 系统自动保存草稿（防止丢失）
6. **Given** 用户编辑词条, **When** 取消编辑, **Then** 系统提示"未保存的更改将丢失"

---

### User Story 3 - 查看版本历史 (Priority: P2)

用户可以查看词条的所有历史版本，比较不同版本的差异，恢复旧版本。

**Why this priority**: 版本历史保证内容可追溯，支持回滚错误编辑。

**Independent Test**: 用户在词条页面点击"历史"标签，查看所有版本，选择旧版本恢复。

**Acceptance Scenarios**:

1. **Given** 用户查看词条, **When** 点击"历史"标签, **Then** 显示所有历史版本列表（按时间倒序）
2. **Given** 用户查看版本历史, **When** 点击某个版本, **Then** 显示该版本的完整内容
3. **Given** 用户查看版本历史, **When** 选择两个版本比较, **Then** 系统显示差异（Diff 视图）
4. **Given** 用户查看历史版本, **When** 点击"恢复此版本", **Then** 系统基于该版本创建新版本（不删除新版本）
5. **Given** 用户查看版本历史, **When** 版本有 100+, **Then** 支持分页显示
6. **Given** 用户查看版本, **When** 版本包含编辑摘要, **Then** 显示编辑人、时间、摘要

---

### User Story 4 - 词条分类和标签 (Priority: P1)

用户可以为词条设置分类和标签，方便组织和检索知识内容。

**Why this priority**: 分类和标签帮助用户导航和发现相关词条。

**Independent Test**: 用户创建词条时选择分类"编程语言"和标签"JavaScript, 前端"，验证词条在对应分类下显示。

**Acceptance Scenarios**:

1. **Given** 用户创建词条, **When** 选择分类（单选）, **Then** 词条归属到该分类
2. **Given** 用户创建词条, **When** 添加多个标签（多选）, **Then** 词条关联到所有标签
3. **Given** 用户查看分类页面, **When** 点击分类, **Then** 显示该分类下的所有词条
4. **Given** 用户点击标签, **When** 跳转到标签页面, **Then** 显示所有包含该标签的词条
5. **Given** 系统预设分类, **When** 用户查看分类列表, **Then** 显示预设分类（如技术、科学、历史、艺术等）
6. **Given** 用户输入标签, **When** 标签已存在, **Then** 系统自动补全建议

---

### User Story 5 - 词条搜索 (Priority: P1)

用户可以在 Wiki 中搜索词条，按标题或内容查找相关知识。

**Why this priority**: 搜索是知识检索的核心功能，帮助用户快速找到需要的词条。

**Independent Test**: 用户在搜索框输入"Vue"，验证返回所有标题或内容包含"Vue"的词条。

**Acceptance Scenarios**:

1. **Given** 用户在 Wiki 搜索框输入关键词, **When** 按回车搜索, **Then** 返回匹配的词条列表
2. **Given** 用户搜索词条, **When** 搜索结果有多页, **Then** 支持分页显示
3. **Given** 用户搜索无结果, **When** 没有匹配的词条, **Then** 显示"未找到相关词条，是否创建？"
4. **Given** 用户搜索结果, **When** 点击词条, **Then** 跳转到词条详情页
5. **Given** 搜索结果, **When** 包含关键词, **Then** 高亮显示匹配的关键词
6. **Given** 用户搜索, **When** 输入词条标题, **Then** 优先显示标题完全匹配的词条

---

### User Story 6 - 词条链接引用 (Priority: P2)

用户可以在词条内容中插入链接引用其他词条，形成知识网络。

**Why this priority**: 词条链接是 Wiki 的核心特性，帮助用户探索相关知识。

**Independent Test**: 用户在词条内容中输入 `[[Vue.js]]`，验证渲染为指向 Vue.js 词条的链接。

**Acceptance Scenarios**:

1. **Given** 用户编辑词条, **When** 输入 `[[词条标题]]`, **Then** 系统渲染为指向该词条的链接
2. **Given** 用户点击词条链接, **When** 目标词条存在, **Then** 跳转到目标词条页面
3. **Given** 用户点击词条链接, **When** 目标词条不存在, **Then** 显示"词条不存在，点击创建"
4. **Given** 用户查看词条, **When** 词条被其他词条引用, **Then** 显示"被引用列表"（反向链接）
5. **Given** 用户编辑词条, **When** 输入 `[[别名|显示文本]]`, **Then** 渲染为带自定义文本的链接
6. **Given** 用户查看词条链接, **When** 链接断裂（目标被删除）, **Then** 显示红色链接或删除线

---

### User Story 7 - 协作编辑 (Priority: P3)

多个用户可以协作编辑同一词条，系统记录所有编辑历史和贡献者。

**Why this priority**: 协作编辑是 Wiki 的核心理念，鼓励集体智慧。

**Independent Test**: 用户 A 编辑词条后，用户 B 再次编辑同一词条，验证两个版本都被记录。

**Acceptance Scenarios**:

1. **Given** 用户 A 编辑词条, **When** 保存后, **Then** 系统记录 A 为该版本的编辑者
2. **Given** 用户 B 编辑同一词条, **When** 保存后, **Then** 系统记录 B 为新版本的编辑者
3. **Given** 词条有多个编辑者, **When** 查看词条, **Then** 显示"贡献者列表"（所有编辑过的用户）
4. **Given** 用户编辑词条, **When** 填写编辑摘要, **Then** 版本历史中显示摘要（如"修正错别字"）
5. **Given** 用户查看版本历史, **When** 查看编辑者信息, **Then** 显示编辑者头像和用户名
6. **Given** 用户协作编辑, **When** 发生编辑冲突, **Then** 系统提示"内容已被其他用户修改，请刷新后重新编辑"

---

### User Story 8 - 词条审核 (Priority: P3)

管理员可以审核新创建或编辑的词条，确保内容质量和准确性。

**Why this priority**: 审核机制保证 Wiki 内容质量，防止垃圾信息和错误内容。

**Independent Test**: 管理员在后台查看待审核词条列表，批准或拒绝词条发布。

**Acceptance Scenarios**:

1. **Given** 系统启用审核功能, **When** 用户创建词条, **Then** 词条标记为待审核状态（不公开显示）
2. **Given** 管理员查看待审核列表, **When** 点击"批准", **Then** 词条变为公开状态
3. **Given** 管理员查看待审核列表, **When** 点击"拒绝", **Then** 词条被拒绝并通知作者
4. **Given** 管理员审核词条, **When** 拒绝时填写原因, **Then** 作者收到拒绝原因通知
5. **Given** 系统未启用审核, **When** 用户创建词条, **Then** 词条立即公开（默认信任用户）
6. **Given** 词条被编辑, **When** 启用编辑审核, **Then** 编辑需要审核才能生效

---

### Edge Cases

- **词条标题冲突**: 两个用户同时创建同名词条，如何处理
- **词条删除**: 词条被删除后，引用该词条的链接如何处理
- **大量编辑历史**: 词条被编辑 1000+ 次，版本历史如何优化加载
- **词条重定向**: 词条重命名后，旧标题是否自动重定向到新标题
- **词条锁定**: 重要词条是否支持锁定（仅管理员可编辑）
- **词条模板**: 是否支持词条模板（如人物、地点、事件模板）
- **词条讨论**: 是否需要词条讨论页（类似维基百科的 Talk 页面）
- **词条统计**: 词条浏览次数、编辑次数、贡献者数量是否需要统计

## Requirements *(mandatory)*

### Functional Requirements

#### 词条创建和发布
- **FR-001**: 用户 MUST 能够创建新词条并设置标题和内容
- **FR-002**: 词条标题 MUST 限制在 200 字符以内
- **FR-003**: 词条内容 MUST 限制在 50000 字符以内
- **FR-004**: 词条标题 MUST 唯一（不允许重复）
- **FR-005**: 用户 MUST 能够为词条选择分类（单选）
- **FR-006**: 用户 MUST 能够为词条添加标签（多选，最多 10 个）
- **FR-007**: 词条 MUST 支持 Markdown 格式
- **FR-008**: 词条发布成功后 SHOULD 生成"创建词条"动态事件

#### 词条编辑
- **FR-009**: 用户 MUST 能够编辑已有的词条
- **FR-010**: 每次编辑 MUST 创建新的版本记录
- **FR-011**: 用户 SHOULD 能够填写编辑摘要（描述本次修改）
- **FR-012**: 编辑摘要 MUST 限制在 200 字符以内
- **FR-013**: 系统 SHOULD 支持编辑草稿自动保存（防止内容丢失）
- **FR-014**: 用户 MUST 能够取消编辑（放弃未保存的更改）

#### 版本历史
- **FR-015**: 词条 MUST 记录所有编辑历史版本
- **FR-016**: 版本 MUST 包含以下信息：版本号、编辑者、编辑时间、编辑摘要、内容快照
- **FR-017**: 用户 MUST 能够查看词条的所有历史版本
- **FR-018**: 用户 MUST 能够查看任意版本的完整内容
- **FR-019**: 用户 SHOULD 能够比较两个版本的差异（Diff 视图）
- **FR-020**: 用户 MUST 能够恢复到旧版本（创建新版本，而非删除新版本）
- **FR-021**: 版本历史 MUST 支持分页显示

#### 词条分类和标签
- **FR-022**: 系统 MUST 支持词条分类（预设或用户自定义）
- **FR-023**: 系统 SHOULD 提供预设分类（如技术、科学、历史、艺术等）
- **FR-024**: 用户 MUST 能够查看所有分类列表
- **FR-025**: 点击分类 MUST 显示该分类下的所有词条
- **FR-026**: 系统 MUST 支持词条标签（全站共享）
- **FR-027**: 标签输入 SHOULD 支持自动补全建议
- **FR-028**: 点击标签 MUST 显示所有包含该标签的词条

#### 词条搜索
- **FR-029**: 用户 MUST 能够搜索词条（按标题或内容）
- **FR-030**: 搜索 MUST 支持模糊匹配（LIKE 查询或全文搜索）
- **FR-031**: 搜索结果 MUST 优先显示标题匹配的词条
- **FR-032**: 搜索结果 SHOULD 高亮显示匹配的关键词
- **FR-033**: 搜索无结果时 SHOULD 提示"是否创建该词条？"
- **FR-034**: 搜索结果 MUST 支持分页，每页显示 20 条

#### 词条链接引用
- **FR-035**: 词条 MUST 支持内部链接语法 `[[词条标题]]`
- **FR-036**: 内部链接 MUST 渲染为指向目标词条的超链接
- **FR-037**: 点击存在的词条链接 MUST 跳转到目标词条
- **FR-038**: 点击不存在的词条链接 SHOULD 显示"词条不存在，点击创建"
- **FR-039**: 词条 SHOULD 显示"被引用列表"（反向链接，哪些词条引用了本词条）
- **FR-040**: 系统 SHOULD 支持链接别名语法 `[[目标|显示文本]]`

#### 协作编辑
- **FR-041**: 系统 MUST 记录每个版本的编辑者
- **FR-042**: 词条 MUST 显示贡献者列表（所有编辑过的用户）
- **FR-043**: 系统 SHOULD 检测编辑冲突（两个用户同时编辑）
- **FR-044**: 编辑冲突时 SHOULD 提示用户刷新并合并更改

#### 词条审核
- **FR-045**: 系统 SHOULD 支持词条审核功能（可配置开启/关闭）
- **FR-046**: 启用审核时，新创建的词条 MUST 标记为待审核状态
- **FR-047**: 待审核词条 MUST 不对外显示，仅作者和管理员可见
- **FR-048**: 管理员 MUST 能够批准或拒绝待审核词条
- **FR-049**: 拒绝词条时 SHOULD 填写拒绝原因并通知作者
- **FR-050**: 系统 SHOULD 支持编辑审核（编辑需要审核才能生效）

#### 词条管理
- **FR-051**: 用户 MUST 能够删除自己创建的词条
- **FR-052**: 管理员 MUST 能够删除任何词条
- **FR-053**: 删除词条 MUST 需要确认（防止误删）
- **FR-054**: 词条 MUST 记录创建时间、最后编辑时间、浏览次数
- **FR-055**: 词条 SHOULD 支持锁定功能（仅管理员可编辑）

### Key Entities

#### Wiki (Wiki 词条实体)
- **Id** (long, 主键): 词条 ID
- **Title** (string, 200字符): 词条标题（唯一）
- **Content** (text): 当前版本的内容
- **CategoryId** (long, 外键, 可选): 分类 ID
- **CreatorId** (long, 外键): 创建者用户 ID
- **CreateTime** (DateTime): 创建时间
- **LastEditorId** (long, 外键): 最后编辑者用户 ID
- **LastEditTime** (DateTime): 最后编辑时间
- **ViewCount** (int): 浏览次数
- **EditCount** (int): 编辑次数（冗余字段）
- **Status** (enum): 词条状态（Published=0, Pending=1, Deleted=2, Locked=3）
- **唯一索引**: (Title) 防止标题重复
- **索引**: (CategoryId, LastEditTime) 用于分类查询
- **全文索引**: (Title, Content) 用于搜索

#### WikiVersion (Wiki 版本历史实体)
- **Id** (long, 主键): 版本 ID
- **WikiId** (long, 外键): 词条 ID
- **VersionNumber** (int): 版本号（从 1 开始递增）
- **Content** (text): 该版本的完整内容
- **EditorId** (long, 外键): 编辑者用户 ID
- **EditTime** (DateTime): 编辑时间
- **EditSummary** (string, 200字符, 可选): 编辑摘要
- **索引**: (WikiId, VersionNumber) 用于版本查询

#### WikiCategory (Wiki 分类实体)
- **Id** (long, 主键): 分类 ID
- **Name** (string, 50字符): 分类名称
- **Description** (string, 200字符, 可选): 分类描述
- **ParentId** (long, 可选): 父分类 ID（支持层级分类）
- **CreateTime** (DateTime): 创建时间

#### WikiTag (Wiki 标签关联表)
- **WikiId** (long, 外键): 词条 ID
- **TagId** (long, 外键): 标签 ID
- **联合主键**: (WikiId, TagId)

#### Tag (标签实体 - 复用)
- **Id** (long, 主键): 标签 ID
- **Name** (string, 50字符): 标签名称
- **UseCount** (int): 使用次数
- **CreateTime** (DateTime): 创建时间

#### WikiLink (Wiki 链接引用表 - 可选)
- **Id** (long, 主键): 链接 ID
- **SourceWikiId** (long, 外键): 来源词条 ID
- **TargetWikiTitle** (string, 200字符): 目标词条标题
- **LinkText** (string, 200字符, 可选): 链接显示文本
- **CreateTime** (DateTime): 创建时间
- **索引**: (TargetWikiTitle) 用于反向链接查询

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 词条创建操作在 1 秒内完成
- **SC-002**: 词条列表在 500 毫秒内加载完成（100 个词条）
- **SC-003**: 词条搜索在 1 秒内返回结果（1000 个词条）
- **SC-004**: 版本历史在 1 秒内加载完成（100 个版本）
- **SC-005**: 版本差异比较在 2 秒内完成
- **SC-006**: 词条编辑保存在 1 秒内完成
- **SC-007**: 用户平均每月创建或编辑 5 个以上词条
- **SC-008**: 词条协作编辑率 > 30%（30% 的词条有多个编辑者）
- **SC-009**: 词条搜索使用率 > 50%（用户通过搜索发现词条）
- **SC-010**: 词条链接引用率 > 20%（20% 的词条包含内部链接）

## Assumptions *(optional)*

### Technical Assumptions
- 词条内容使用 Markdown 格式存储
- 版本历史存储完整内容快照（不使用 Diff）
- 词条搜索使用数据库全文索引或 Elasticsearch
- 词条链接使用正则表达式解析 `[[词条标题]]`
- 编辑冲突检测使用版本号或时间戳

### Business Assumptions
- 用户平均创建 10 个词条
- 大部分词条是独立创建（非协作编辑）
- 词条平均被编辑 3-5 次
- 词条平均包含 2-3 个内部链接
- 词条审核主要用于公共 Wiki 或敏感内容

### User Experience Assumptions
- 用户期望 Wiki 编辑操作简单（类似维基百科）
- 用户希望看到词条的版本历史（了解演变过程）
- 用户希望词条链接形成知识网络
- 用户希望搜索快速准确（找到需要的词条）

## Dependencies *(optional)*

### Internal Dependencies
- **用户认证与授权系统 (#001)**: 提供用户身份验证
- **用户资料系统 (#002)**: 提供用户头像和用户名
- **活动动态系统 (#005)**: 生成"创建词条"动态事件
- **评论系统 (#008)**: 可选，支持词条讨论页
- 通知系统（未来）: 集成编辑通知、审核通知

### External Dependencies
- **Markdown 渲染库**: 前端使用 marked.js 或 markdown-it
- **代码高亮库**: 前端使用 Prism.js 或 highlight.js
- **Diff 库**: 前端使用 diff-match-patch 或 jsdiff
- **数据库全文搜索**: PostgreSQL FTS 或 Elasticsearch

## Out of Scope *(optional)*

以下功能**不在**本次规格范围内：

- 词条讨论页（Talk 页面） - 属于扩展功能
- 词条模板系统 - 属于高级功能
- 词条重定向（标题重命名后自动跳转） - 属于扩展功能
- 词条合并功能（合并重复词条） - 属于管理功能
- 词条导出（PDF, Markdown 文件） - 属于工具功能
- 词条权限控制（特定用户可编辑） - 属于高级权限
- 词条翻译功能（多语言版本） - 属于国际化功能
- 词条统计分析（热门词条、编辑趋势） - 属于数据分析

## Notes *(optional)*

### Security Considerations
- 词条标题必须唯一，防止冲突
- 词条内容必须过滤危险 HTML 标签（防止 XSS）
- 词条编辑需要验证用户权限（普通用户 vs 管理员）
- 词条审核防止垃圾内容和错误信息

### Performance Considerations
- 词条列表查询使用索引（Title, CategoryId, LastEditTime）
- 版本历史使用分页减少查询压力
- 词条搜索使用全文索引（PostgreSQL FTS）
- 词条浏览次数使用异步更新
- 版本内容使用完整快照（简化查询，但占用存储空间）

### Scalability Considerations
- 词条表按 ID 或时间分表
- 版本历史表按 WikiId 分表
- 历史版本可以归档到冷存储（如超过 1 年的版本）
- 词条搜索使用 Elasticsearch（高并发场景）

### User Experience Considerations
- 词条编辑支持 Markdown 实时预览
- 词条链接自动补全（输入 `[[` 时提示词条标题）
- 版本差异使用颜色标识（绿色添加，红色删除）
- 词条搜索结果高亮关键词
- 词条编辑支持草稿自动保存

### Open Questions for Future Iterations
- 是否需要支持词条讨论页（类似维基百科 Talk）？
- 是否需要词条模板系统？
- 是否需要词条重定向功能？
- 是否需要词条权限控制（特定用户可编辑）？
- 是否需要词条翻译功能（多语言版本）？
- 版本历史存储完整快照还是使用 Diff（权衡存储和性能）？
